 (() =>{
    String.prototype.ensureStart = function (st) {
        let strValue = this.toString()
        if (!strValue.startsWith(st)) {
            return this.replace(/^/, st).toString()
        }
        return this.toString()
    }
    
    String.prototype.ensureEnd = function (st) {
        let strValue = this.toString()
        if (!strValue.endsWith(st)) {
            return this.replace(/$/, st).toString();
        }
        return this.toString()
    
    }
    
    String.prototype.isEmpty = function () {
        return this.toString() === "" ? true : false
    }
    
    String.prototype.truncate = function (n) {
      
        let strValue = this.toString()
  
        if (n <= 3){ return '.'.repeat(n)}

        if (strValue.length <= n){ return this.toString()}

        let lastIndex = strValue.substr(0, n - 2).lastIndexOf(" ")
        if (lastIndex != -1) {
            return strValue.substr(0, lastIndex) + "..."
        } else {
            return strValue.substr(0, n - 3) + "..."
        }
    
    }
    
    String.format = function (str,...params) {
    
        for (let i = 0; i < params.length; i++) {
            let index = str.indexOf("{" + i + "}")
            while (index != -1) {
                str = str.replace("{" + i + "}", params[i]);
                index = str.indexOf("{" + i + "}")
            }
        }
        return str
    }
})()

