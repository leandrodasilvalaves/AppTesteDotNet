
var SERVICEBASE = window.location.origin + '/api/';


var getIdFromUrl = function () {
    var index = location.toString().indexOf('=');
    var id = parseInt(location.toString().substring(index + 1));
    return id;
};

var executarResponseNonQuery = function (response, _location) {
    response.then(function (resp) {
        location = _location;
    }, function (err) {
        console.log(err);
    });
};

var gerarSlug = function (texto) {
    if (texto == undefined || texto == null)
        return;
    return texto.replace(/\s\w{1,2}\s/g, '-').replace(/\s/g, '-').toLowerCase();
}

var autoSlug = function (origem, destino) {
    var _origem = document.getElementById(origem);
    var _destino = document.getElementById(destino);
    _destino.value = gerarSlug(_origem.value);
}

var criarFormNaDom = function (data) {
    var template = `
        <div class="container my-form">
            <form>
              ` + prepararTemplate(data) + `
            </form>
        </div>`;
    $("#contentForms").append(template);

}

var prepararTemplate = function (data) {
    var template = "";
    data.forEach(function (e) {
        template += `
            <div class="form-group">
                <label>` + e.Descricao + `</label>`
                + e.HTML +
            `</div>`;
    });
    return template;
}