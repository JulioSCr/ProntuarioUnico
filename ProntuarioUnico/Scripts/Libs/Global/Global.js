function FormataDataStr(vobjValue, vblnHora, vblnMinuto, vblnSegundo) {
    var lstrData = new String('');

    try {
        vblnMinuto = Nvl(vblnMinuto, Nvl(vblnHora, true));
        vblnSegundo = Nvl(vblnSegundo, Nvl(vblnHora, true));

        if (vobjValue != null && vobjValue != undefined) {
            if (typeof (vobjValue) == 'string') {
                vobjValue = new Date(vobjValue);
            }
            lstrData = (vobjValue.getDate() < 10 ? '0' + vobjValue.getDate() : vobjValue.getDate());
            lstrData = lstrData + '/' + ((vobjValue.getMonth() + 1) < 10 ? '0' + (vobjValue.getMonth() + 1) : (vobjValue.getMonth() + 1));
            lstrData = lstrData + '/' + (vobjValue.getFullYear());
            if (vblnHora == null || vblnHora == undefined || vblnHora == true) {
                lstrData = lstrData + ' ' + (vobjValue.getHours() < 10 ? '0' + vobjValue.getHours() : vobjValue.getHours());
            }
            if (vblnMinuto == null || vblnMinuto == undefined || vblnMinuto == true) {
                lstrData = lstrData + ':' + (vobjValue.getMinutes() < 10 ? '0' + vobjValue.getMinutes() : vobjValue.getMinutes());
            }
            if (vblnSegundo == null || vblnSegundo == undefined || vblnSegundo == true) {
                lstrData = lstrData + ':' + (vobjValue.getSeconds() < 10 ? '0' + vobjValue.getSeconds() : vobjValue.getSeconds());
            }
        }

        return lstrData;
    } catch (ex) {
        throw ex;
    }
}

function Agora(vstrTipo) {
    try {
        var ldatAgora = new Date();

        if (Nvl(vstrTipo, 'F') == 'I') {
            ldatAgora.setHours(0);
            ldatAgora.setMinutes(0);
            ldatAgora.setSeconds(0);
            ldatAgora.setMilliseconds(0);
        } else if (vstrTipo == 'F') {
            ldatAgora.setHours(23);
            ldatAgora.setMinutes(59);
            ldatAgora.setSeconds(59);
            ldatAgora.setMilliseconds(0);
        }

        return ldatAgora;
    } catch (ex) {
        throw ex;
    }
}

function getGlobalPath() {
    var lobjLocation = new Object();
    var lstrGlobalPath = new String();
    var larrPath = new Array();
    try {
        lobjLocation = window.location;
        larrPath = lobjLocation.pathname.split('/');
        lstrGlobalPath = lobjLocation.protocol + '//' + lobjLocation.host + '/' + larrPath[1] + '/' + larrPath[2] + '/' + larrPath[3] + '/' + larrPath[4];
        return lstrGlobalPath;
    } catch (ex) {
        throw ex;
    }
}

function Nvl(vobjValor, vobjValorSeNulo) {
    var lobjRetorno;
    if (vobjValor == null || vobjValor == undefined) {
        lobjRetorno = vobjValorSeNulo;
    } else {
        lobjRetorno = vobjValor;
    }

    return lobjRetorno;
}

function LoadScript(vstrNome, vstrGolbalPath) {
    var lobjScript = new Object();
    try {
        lobjScript = document.createElement('script');
        lobjScript.type = 'text/javascript';
        lobjScript.src = vstrGolbalPath + vstrNome + '?' + FormataDataStr(Agora(), true).replace(' ', '').split('/').join('').split(':').join('');

        document.head.appendChild(lobjScript);
    } catch (ex) {
        throw ex;
    }
}

function LoadCss(vstrNome, vstrGolbalPath) {
    var lobjScript = new Object();
    try {
        lobjCss = document.createElement('link');
        lobjCss.type = 'text/css';
        lobjCss.rel = 'stylesheet';
        lobjCss.href = vstrGolbalPath + vstrNome + '?' + FormataDataStr(Agora(), true).replace(' ', '').split('/').join('').split(':').join('');
        document.head.appendChild(lobjCss);
    } catch (ex) {
        throw ex;
    }
}

$(window).on('load', function () {
    //Altera o cursor do body para o default
    document.body.style.cursor = 'auto';
    //Visualiza o conteúdo da tela
    document.querySelector('[load]').style.display = '';
    document.querySelector('[load]').removeAttribute('load');
});