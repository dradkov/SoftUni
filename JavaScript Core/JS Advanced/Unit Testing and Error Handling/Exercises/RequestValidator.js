function validateRequest(obj) {
    
    let validMetods = ['GET','POST','DELETE','CONNECT']
    let validVersion = ['HTTP/0.9','HTTP/1.0', 'HTTP/1.1','HTTP/2.0']
    let messageRgx = /^[^<>\\&'"]*$/;
    let uriRgx = /^[\w.]+$/;

    if (!(obj.method && validMetods.includes(obj.method))) {
        throw new Error('Invalid request header: Invalid Method')
    }
    if (!(obj.uri && (uriRgx.test(obj.uri)||obj.uri === '*'))) {
        throw new Error('Invalid request header: Invalid URI')
    }
    if (!(obj.version && validVersion.includes(obj.version))) {
        throw new Error('Invalid request header: Invalid Version')
    }
    if (!(obj.hasOwnProperty('message') && (messageRgx.test(obj.message) || obj.message == ""))) {
        throw new Error('Invalid request header: Invalid Message')
    }

    return obj
}

validateRequest({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
  });
  