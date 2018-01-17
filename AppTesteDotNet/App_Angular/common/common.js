var SERVICEBASE = window.location.origin + '/api/';

var getIdFromUrl = function () {
    var index = location.toString().indexOf('=');
    var id = parseInt(location.toString().substring(index + 1));
    return id;
};