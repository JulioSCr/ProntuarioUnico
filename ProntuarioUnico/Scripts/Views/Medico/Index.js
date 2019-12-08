function ControleCheckBox(controle) {
	var nomeInputSenhaAntiga = 'input[name^="medicoViewModel.SenhaAntiga"]';
	var nomeInputNovaSenha = 'input[name^="medicoViewModel.NovaSenha"]';
	var nomeInputConfirmarNovaSenha = 'input[name^="medicoViewModel.ConfirmarSenhaNova"]';

	var inputSenhaAntiga = $(nomeInputSenhaAntiga);
	var inputNovaSenha = $(nomeInputNovaSenha);
	var inputConfirmarNovaSenha = $(nomeInputConfirmarNovaSenha);

	inputSenhaAntiga[0].disabled = !controle.checked;
	inputNovaSenha[0].disabled = !controle.checked;
	inputConfirmarNovaSenha[0].disabled = !controle.checked;

	inputSenhaAntiga[0].value = "";
	inputNovaSenha[0].value = "";
	inputConfirmarNovaSenha[0].value = "";
}
