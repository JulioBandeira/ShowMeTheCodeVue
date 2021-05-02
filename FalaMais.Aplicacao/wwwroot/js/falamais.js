

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
        },
        returnResultado() {

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
        }
    },
    created() {
        this.returnOrigens()
    }
})
