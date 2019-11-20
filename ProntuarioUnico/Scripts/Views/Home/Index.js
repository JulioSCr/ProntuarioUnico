var Index = window.Index || {

}

Index.MontarTela = function () {
    try {
        Index.CriarComponentes();
    } catch (ex) {
        alert(ex);
    }
}

Index.CriarComponentes = function () {
    try {
        $('.cssIndex_TbProntuario_Row').click(function () {
            Index.TbProntuario_Expandir($(this)[0]);
        });
    } catch (ex) {
        alert(ex);
    }
}

Index.TbProntuario_Expandir = function (vobjElmento) {
    try {
        if ($(vobjElmento.nextElementSibling).css('display') == 'table-row') {
            $(vobjElmento.nextElementSibling).css({ display: 'none' })
            vobjElmento.children[3].children[0].children[0].src = gstrGlobalPath + '/Content/Imagens/Home/imgDown.png'
        } else {
            $(vobjElmento.nextElementSibling).css({ display: 'table-row' })
            vobjElmento.children[3].children[0].children[0].src = gstrGlobalPath + '/Content/Imagens/Home/imgUp.png'
        }
    } catch (ex) {
        alert(ex);
    }
}

// Ativa assim que a página é totalmente renderizada
//$(document).ready({

//    Index.MontarTela();
//});
$(document).ready(function () {
    Index.MontarTela();
});