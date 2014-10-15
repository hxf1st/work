
$.fn.tabPages = function (options) {
    var self = this;
    var options = $.extend({

    }, options || {});
    var tabs = new TabPages(self, options);

    return tabs;
};

function TabPages(self, options) {
    var self = self;
    this.hashtable = new Array();
    this.options = $.extend({
				lock: false,
				tabDropLabel: 'More...',
        panelContainer: (function () {
            var tick = new Date().getTime();
            var panelElement = $('<div class="tab-content" id="tabsPanelContainer' + tick + '"></div>');
            self.append(panelElement);
            return panelElement;
        })(),
        tabHeaderTemplate: '<li id="tabHeader-#{id}" class="tabli"><a data-toggle="tab" href="#tabPanel-#{id}">#{label}</a></li>',
        tabPanelTemplate: '<div id="tabPanel-#{id}" class="tab-pane" style="height: 100%;"><iframe frameBorder="0" style="width: 100%; display: inline; height: 100%;" src="#{src}"></iframe></div>',
        uidGenerator: function () { return new Date().getTime(); }
    }, options || {});

    this.wrapper = self;
    var el = self.find('ol,ul').eq(0);
    this.element = el;
    if(!this.element.hasClass("nav nav-tabs"))
        this.element.addClass("nav nav-tabs");
    var pc = this.options.panelContainer;
    this.panelContainer = pc;
    this.panelContainer.addClass("tab-content");

    if (this instanceof TabPages) {
        TabPages.prototype.resizePanelContainer = function () {
            if (pc.attr('id').indexOf('tabsPanelContainer') === 0) {
                pc.css("height",document.documentElement.clientHeight-110);
            }
        }
    }
};

TabPages.prototype.add = function (options) {
    var self = this;
    var uid = self.options.uidGenerator(self);

    var options = $.extend({
        id: uid,
        url: '#',
        label: 'New Tab',
        onTabClose: function () { },
        onTabRegister: function() { }
    }, options || {});

    var exsitsTab = self.getTabByUrl(options.url);
    if (exsitsTab) {
        if (!exsitsTab.activate()) {
            return false;
        }
    }

    var tabHeader = $(self.options.tabHeaderTemplate
    .replace(/#\{id\}/g, options.id)
    .replace(/#\{label\}/g, function () {
        if (options.label.length > 10) {
            return options.label.substring(0, 10) + '...';
        }
        return options.label;
    } ()));
    var panel = $(self.options.tabPanelTemplate
        .replace(/#\{id\}/g, options.id)
        .replace(/#\{src\}/g, options.url.toLowerCase()));

    self.element.append(tabHeader);
    self.panelContainer.append(panel);
    self.hashtable[options.id] = { 'onTabClose': options.onTabClose, 'onTabRegister': options.onTabRegister };

    options.onTabRegister(tabHeader, panel);
    var tab = new TabPage(self, options.id);
    tab.setLock(options.lock);
    tab.activate();
    self.resizePanelContainer();

    self.element.tabdrop({ text: self.options.tabDropLabel })
    return tab;
};

TabPages.prototype.refresh = function(tab, url, label) {
    tab.header.find('a:first').text(label);
    tab.panel.find(' > iframe:first').attr('src',url);
    tab.activate();;
}


TabPages.prototype.getCurrentUniqueId = function() {
	var self = this;
	var elements = self.element.find('li.tabli');
	if (self.element.find('li.tabli').size() > 0) {
		var current = self.element.find('li.active:not(.dropdown)');
		return current.size() > 0 ? TabPage.getUniqueByHeaderId(current.attr('id')) : null;
	} else {
		return null;
	}
}

TabPages.prototype.getCurrentTab = function () {
    var self = this;
    var uid = self.getCurrentUniqueId();
    return uid ? new TabPage(self, self.getCurrentUniqueId()) : null;
}

TabPages.prototype.getTabByUrl = function (url) {
    if (!url) {
        return null;
    }
    var self = this;
    var frames = self.panelContainer.find('div[id^="tabPanel-"]>iframe');
    var tab;
    for (i = 0; i < frames.size(); i++) {
        var frame = $(frames[i]);
        var src = frame.attr('src');
        if (src == url.toLowerCase()) {
            tab = new TabPage(self, TabPage.getUniqueByPanelId(frame.parent('div:first').attr('id')));
        }
    }
    return tab;
}

function TabPage(tabs, id) {
    this.tabs = tabs;
    this.id = id
    this.header = this.tabs.element.find('li#' + TabPage.getFullHeaderId(id));
    this.headerId = this.header.attr('id');
    this.panel = tabs.panelContainer.find('div#' + TabPage.getFullPanelId(id));
    this.panelId = this.panel.attr('id');
    this.label = (this.header ? this.header.find('a:first').text() : null);
    this.url = (this.panel ? this.panel.find(' > iframe:first').attr('src') : null);
    this.onTabRegister = this.tabs.hashtable[id].onTabRegister;
    this.onTabClose = this.tabs.hashtable[id].onTabClose;
};

TabPage.prototype.deactivate = function () {
    var self = this;
    self.header.removeClass('active');
    self.panel.removeClass('active');
}

TabPage.prototype.activate = function () {
    var self = this;

    var currentTab = self.tabs.getCurrentTab();
    if (currentTab) {
        if (currentTab.id == self.id) {
            return false;
        }
        currentTab.deactivate();
    }

    self.header.addClass('active');
    self.panel.addClass('active');

}

TabPage.prototype.prevTab = function() {
	var self = this;
	var prev = self.header.prev();

	if (prev.length == 0) {
		prev = self.tabs.element.children(":last");

		if (self.tabs.element.find("li.tabdrop")) {
			self.tabs.element.data('tabdrop').dropdown.removeClass('active').addClass('hide');
		}
	}


	if (prev.size() > 0) {
		var headerId = prev.attr('id');
		return new TabPage(tabs, TabPage.getUniqueByHeaderId(headerId));
	} else {
		return null;
	}
}

TabPage.prototype.nextTab = function () {
    var self = this;
    var next = self.header.next();
    if (next.size() > 0) {
        var headerId = next.attr('id');
        return new TabPage(tabs, TabPage.getUniqueByHeaderId(headerId));
    } else {
        return null;
    }
}

TabPage.prototype.kill = function () {
    var self = this;
    if (self.lock) {
        return;
    }
    var nextTab = self.nextTab();
    if (!nextTab) {
        nextTab = self.prevTab();
    }
    var onTabClose = self.onTabClose;

    self.header.remove();
    self.panel.remove();
    delete self.tabs.hashtable[self.id];

    
    if (nextTab) {
        nextTab.activate();
    }
    onTabClose(nextTab);
}

TabPage.prototype.setLock = function (lock) {
    var self = this;
    if (!lock) {
        var btnLock = this.header.find('button.close');
        if (btnLock.size() > 0) {
            btnLock.remove();
        }
        var btnClose = $('<button type="button" class="close"><span>&times;</span></button>');
        this.header.find("a").append(btnClose);
        btnClose.bind('click', function () {
            new TabPage(self.tabs, self.id).kill();
        });
    } 
}

TabPage.getUniqueByHeaderId = function (id) {
		if(id != undefined)
			return id.replace('tabHeader-', '');
}

TabPage.getUniqueByPanelId = function (id) {
		if (id != undefined)
				return id.replace('tabPanel-', '');
}

TabPage.getFullHeaderId = function (uid) {
    return 'tabHeader-'.concat(uid);
}

TabPage.getFullPanelId = function(uid) {
	return 'tabPanel-'.concat(uid);
}


!function($) {

	var WinReszier = (function() {
		var registered = [];
		var inited = false;
		var timer;
		var resize = function(ev) {
			clearTimeout(timer);
			timer = setTimeout(notify, 100);
		};
		var notify = function() {
			for (var i = 0, cnt = registered.length; i < cnt; i++) {
				registered[i].apply();
			}
		};
		return {
			register: function(fn) {
				registered.push(fn);
				if (inited === false) {
					$(window).bind('resize', resize);
					inited = true;
				}
			},
			unregister: function(fn) {
				for (var i = 0, cnt = registered.length; i < cnt; i++) {
					if (registered[i] == fn) {
						delete registered[i];
						break;
					}
				}
			}
		}
	} ());

	var TabDrop = function(element, options) {
		this.element = $(element);
		this.dropdown = $('<li class="dropdown hide pull-right tabdrop"><a class="dropdown-toggle" data-toggle="dropdown" href="#">' + options.text + ' <b class="caret"></b></a><ul class="dropdown-menu"></ul></li>')
							.prependTo(this.element);
		if (this.element.parent().is('.tabs-below')) {
			this.dropdown.addClass('dropup');
		}
		WinReszier.register($.proxy(this.layout, this));
		this.layout();
	};

	TabDrop.prototype = {
		constructor: TabDrop,

		layout: function() {
			var collection = [];
			this.dropdown.removeClass('hide');
			this.element
				.append(this.dropdown.find('li'))
				.find('>li')
				.not('.tabdrop')
				.each(function() {
					if (this.offsetTop > 0) {
						collection.push(this);
					}
				});
			if (collection.length > 0) {
				collection = $(collection);
				this.dropdown
					.find('ul')
					.empty()
					.append(collection);
				if (this.dropdown.find('.active').length == 1) {
					this.dropdown.addClass('active');
				} else {
					this.dropdown.removeClass('active');
				}
			} else {
				this.dropdown.addClass('hide');
			}
		}
	}

	$.fn.tabdrop = function(option) {
		return this.each(function() {
			var $this = $(this),
				data = $this.data('tabdrop'),
				options = typeof option === 'object' && option;
			if (!data) {
				tab = new TabDrop(this, $.extend({}, $.fn.tabdrop.defaults, options));
				$this.data('tabdrop', (data = tab));
			}
			else {
				data.layout();
			}
			if (typeof option == 'string') {
				data[option]();
			}
		})
	};

	$.fn.tabdrop.defaults = {
		text: '<i class="icon-align-justify"></i>'
	};

	$.fn.tabdrop.Constructor = TabDrop;

} (window.jQuery);