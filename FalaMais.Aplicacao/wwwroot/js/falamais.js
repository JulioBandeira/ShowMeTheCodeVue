﻿
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
            valor: 0,
            resultado:'',
        }
    },
  
    watch : {
        tempo() {
            if (this.tempo > 0) 
                return this.returnCalculoConsumo();
        },
        is_fala_mais() {
                return this.returnCalculoConsumo();
        },
        origem() {
            return this.returnCalculoConsumo();
        },
        destino() {
            return this.returnCalculoConsumo();
        },
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
        },
        returnCalculoConsumo() {

            axios.get('/api/falamais/obter/consumo', {
                params: {

                    isfalamais: this.is_fala_mais == 1 ? true : false,
                    origem: this.origem,
                    destino: this.destino,
                    tempo: this.tempo,
                }
            }).then(resp => {

                this.resultado = resp.data;
            });
        }
    },
    created() {
        this.returnOrigens()
    }
})