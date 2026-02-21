
var CookieManager = {
    getCookie: function(name) {
        var decoded = decodeURIComponent(document.cookie);
        var ca = decoded.split(';');
        for(var i=0;i<ca.length;i++) {
            var c = ca[i].trim();
            if (c.indexOf(name+"=") === 0) return c.substring(name.length+1,c.length);
        }
        return null;
    },
    setCookie: function(name,value,expiryDate){
        var str = name+"="+encodeURIComponent(value);
        if(expiryDate) str+="; expires="+expiryDate.toUTCString();
        str+="; path=/";
        document.cookie=str;
    },
    deleteCookie: function(name){
        document.cookie = name+"=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/";
    },
    hasCookie: function(name){
        return this.getCookie(name) !== null;
    }
};
