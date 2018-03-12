let info  = require('./LoadData')

function sort(property) {
    return info.sort((a,b)=> a[property].localeCompare(b[property]))
}

function filter(property, value) {
   return info.filter(a=>a[property] === value)
}

result.sort = sort;
result.filter = filter;

