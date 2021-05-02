

new Vue({
    el: '#app',
    data() {
        return {
            preco: 0,
            tempo: '',
            is_fala_mais: '1',
            origem: '011',
            destino : '',
            options: [
            ],
            options_destino: [
            ],
        }
    },
    computed: {

        resultado() {
            return this.tempo;
        }
    },
    methods: {
        returnOrigens() {

            axios.get('/api/falamais/origens')
                .then(resp => {

                    this.options = resp.data;
                })
                .catch(error => {
                    alert('error')
                })
        },
        returnDestino() {

            axios.get('/api/falamais/destinos', {
                params: {
                   origem: this.origem
                } 
            })
                .then(resp => {

                    this.options_destino = resp.data;
                })
                .catch(error => {
                    alert('error')
                })
        },
        eventReturnDestino() {
            this.returnDestino();
        }
    },
    created() {
        this.returnOrigens()
    }
})


//Vue.component('modal-fornecedor', {
//	template: '#app-model',
//	name: 'modal-fornecedor',
//	data() {
//		return {
//			cpfcnpj: '',
//			nome_fantasia: '',
//		}
//	},
//	computed: {

//		verificaCPFCNPJ: function () {
//			return this.isCPF(this.cpfcnpj) || this.isCNPJ(this.cpfcnpj);
//		},

//		messagemLabelCPF: function () {

//			return (this.cpfcnpj.replace(/[^0-9]/g, '').length == 11 && !this.isCPF(this.cpfcnpj));
//		},

//		messagemLabelCNPJ: function () {

//			// console.log(this.isCPF(this.cpfcnpj))
//			return (this.cpfcnpj.replace(/[^0-9]/g, '').length == 14 && !this.isCNPJ(this.cpfcnpj));
//		}
//	},
//	methods: {

//		isCPF: function () {

//			var cpf = this.cpfcnpj.replace(/[^0-9]/g, '');

//			if (!cpf || cpf.length != 11
//				|| cpf == "00000000000"
//				|| cpf == "11111111111"
//				|| cpf == "22222222222"
//				|| cpf == "33333333333"
//				|| cpf == "44444444444"
//				|| cpf == "55555555555"
//				|| cpf == "66666666666"
//				|| cpf == "77777777777"
//				|| cpf == "88888888888"
//				|| cpf == "99999999999")
//				return false
//			var soma = 0
//			var resto
//			for (var i = 1; i <= 9; i++)
//				soma = soma + parseInt(cpf.substring(i - 1, i)) * (11 - i)
//			resto = (soma * 10) % 11
//			if ((resto == 10) || (resto == 11)) resto = 0
//			if (resto != parseInt(cpf.substring(9, 10))) return false
//			soma = 0
//			for (var i = 1; i <= 10; i++)
//				soma = soma + parseInt(cpf.substring(i - 1, i)) * (12 - i)
//			resto = (soma * 10) % 11
//			if ((resto == 10) || (resto == 11)) resto = 0
//			if (resto != parseInt(cpf.substring(10, 11))) return false
//			return true;
//		},

//		isCNPJ: function () {

//			var cnpj = this.cpfcnpj.replace(/[^0-9]/g, '');

//			if (!cnpj || cnpj.length != 14
//				|| cnpj == "00000000000000"
//				|| cnpj == "11111111111111"
//				|| cnpj == "22222222222222"
//				|| cnpj == "33333333333333"
//				|| cnpj == "44444444444444"
//				|| cnpj == "55555555555555"
//				|| cnpj == "66666666666666"
//				|| cnpj == "77777777777777"
//				|| cnpj == "88888888888888"
//				|| cnpj == "99999999999999")
//				return false
//			var tamanho = cnpj.length - 2
//			var numeros = cnpj.substring(0, tamanho)
//			var digitos = cnpj.substring(tamanho)
//			var soma = 0
//			var pos = tamanho - 7
//			for (var i = tamanho; i >= 1; i--) {
//				soma += numeros.charAt(tamanho - i) * pos--
//				if (pos < 2) pos = 9
//			}
//			var resultado = soma % 11 < 2 ? 0 : 11 - soma % 11
//			if (resultado != digitos.charAt(0)) return false;
//			tamanho = tamanho + 1
//			numeros = cnpj.substring(0, tamanho)
//			soma = 0
//			pos = tamanho - 7
//			for (var i = tamanho; i >= 1; i--) {
//				soma += numeros.charAt(tamanho - i) * pos--
//				if (pos < 2) pos = 9
//			}
//			resultado = soma % 11 < 2 ? 0 : 11 - soma % 11
//			if (resultado != digitos.charAt(1)) return false
//			return true;
//		},

//		btn_modal_salvar: function () {

//			var cpfcnpj = $('#modal-cpf-cnpj').val().replace(/[^0-9]/g, '');

//			if ($('#modal-cpf-cnpj').val() == '' && $('#modal-nome-fantasia').val() == '') {

//				if ($('#modal-cpf-cnpj').val() == '')
//					$($('[data-valmsg-for="modal-error"')[0]).removeClass('hide');

//				if ($('#modal-nome-fantasia').val() == '')
//					$($('[data-valmsg-for="modal-error"')[1]).removeClass('hide');
//			}
//			else
//				$.ajax({

//					url: '/administracao/fornecedor/insere',
//					type: 'GET',
//					data: { nome: $('#modal-nome-fantasia').val(), cpfcnpj: cpfcnpj },

//				}).success(function (data) {
//					data.nome = data.nome + ' - ' + data.cnpjcpf;
//					var newOption = new Option(data.nome, data.id, true, true);
//					$('#FornecedorId').append(newOption).trigger('change');

//					$('#modal-fornecedor').modal('hide');

//				}).fail(function (data) {

//				});
//		},
//	}
//});