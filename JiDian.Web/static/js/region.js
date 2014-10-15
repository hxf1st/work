var regions = [
    { id: 371300, name: "山东省-临沂市" },
    { id: 370200, name: "山东省-青岛市" },
    { id: 370100, name: "山东省-济南市" },
    { id: 371600, name: "山东省-日照市" },
];
function getnamebyid(id){
    name = ""
    $.each(regions,function(i){
        if(regions[i].id==id){
            name = regions[i].name;
            return false;
        }
    })
    return name;
}