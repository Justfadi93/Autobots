function tabfunc() {



    $(".t-tabs").each(function () {

        var idp = '#' + this.id + ' > ul >';

        var numItems = $(idp + "li.fancyTab").length;
        debugger;
        if (numItems === 12) {
            $(idp + "li.fancyTab").width('8.3%');
        }
        if (numItems === 11) {
            $(idp + "li.fancyTab").width('9%');
        }
        if (numItems === 10) {
            $(idp + "li.fancyTab").width('10%');
        }
        if (numItems === 9) {
            $(idp + "li.fancyTab").width('11.1%');
        }
        if (numItems === 8) {
            $(idp + "li.fancyTab").width('12.5%');
        }
        if (numItems === 7) {
            $(idp + "li.fancyTab").width('14.2%');
        }
        if (numItems === 6) {
            $(idp + "li.fancyTab").width('16.666666666666667%');
        }
        if (numItems === 5) {
            $(idp + "li.fancyTab").width('20%');
        }
        if (numItems === 4) {
            $(idp + "li.fancyTab").width('25%');
        }
        if (numItems === 3) {
            $(idp + "li.fancyTab").width('33.3%');
        }
        if (numItems === 2) {
            $(idp + "li.fancyTab").width('50%');
        }
        if (numItems === 1) {
            $(idp + "li.fancyTab").width('100%');
        }
    });

}