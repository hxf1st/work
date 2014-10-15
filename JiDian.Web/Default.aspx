<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JiDian.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
  <head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta charset="utf-8" />
    <title>登录</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

    <link rel="stylesheet" href="/static/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/static/css/font-awesome.min.css" />
    <link rel="stylesheet" href="/static/css/ace-fonts.css" />
    <link rel="stylesheet" href="/static/css/ace.min.css" />

    <!--[if lte IE 9]>
      <link rel="stylesheet" href="/static/css/ace-part2.min.css" />
    <![endif]-->

    <!--[if lte IE 9]>
      <link rel="stylesheet" href="/static/css/ace-ie.min.css" />
    <![endif]-->

    <!--[if lt IE 9]>
    <script src="/static/js/html5shiv.js"></script>
    <script src="/static/js/respond.min.js"></script>
    <![endif]-->
		<script type="text/javascript">
			function check() {
					
			}
		</script>
  </head>

  <body class="login-layout light-login" runat="server">
    <div class="main-container">
      <div class="main-content">
        <div class="row">
          <div class="col-sm-10 col-sm-offset-1" style="margin-top:50px">
            <div class="login-container">

              <div class="space-6"></div>

              <div class="position-relative">
                <div id="login-box" class="login-box visible widget-box no-border">
                  <div class="widget-body">
                    <div class="widget-main">
                      <h4 class="header blue lighter bigger">
                        <i class="ace-icon fa fa-cube"></i> 请输入您的登录信息
                      </h4>

                      <div class="space-6"></div>

                      <form id="form1" runat="server">
                        <fieldset>
                          <label class="block clearfix">
                            <span class="block input-icon input-icon-right">
															<input class="form-control" runat="server" id="account" placeholder="请输入帐号" />
                              <i class="ace-icon fa fa-user"></i>
                            </span>
                          </label>

                          <label class="block clearfix">
                            <span class="block input-icon input-icon-right">
															<input type="password" class="form-control" runat="server" id="pwd" placeholder="请输入密码" />
                              <i class="ace-icon fa fa-lock"></i>
                            </span>
                          </label>

                          <label class="block clearfix">
                            <span class="block input-icon input-icon-right">
															<input  class="form-control" runat="server" id="code" placeholder="请输入验证码" />
															<i class="ace-icon fa">
																<img id="imgVerify" style="height:30px;padding-top:2px" src="VerifyCode.aspx" title="看不清？点击更换" onclick="this.src='VerifyCode.aspx?'+Date.now()" />
															</i>
                            </span>
                          </label>

													<asp:Label id="login_error" runat="server" ForeColor="Red"></asp:Label>

                          <div class="space"></div>
                          <div class="clearfix">
														<asp:Button ID="btn" runat="server" Text="登录" CssClass="width-35 pull-right btn btn-sm btn-primary" OnClientClick="check()" onclick="btn_click" />
                          </div>

                          <div class="space-4"></div>
                        </fieldset>
                      </form>

                    </div>
                  </div>
                </div>

              </div>

            </div>
          </div>
        </div>
      </div>
    </div>

    <!--[if !IE]> -->
    <script type="text/javascript">
      window.jQuery || document.write("<script src='/static/js/jquery.min.js'>"+"<"+"/script>");
    </script>

    <!-- <![endif]-->

    <!--[if IE]>
    <script type="text/javascript">
     window.jQuery || document.write("<script src='/static/js/jquery1x.min.js'>"+"<"+"/script>");
    </script>
    <![endif]-->
    <script type="text/javascript">
      if('ontouchstart' in document.documentElement) document.write("<script src='/static/js/jquery.mobile.custom.min.js'>"+"<"+"/script>");
    </script>

  </body>
</html>
