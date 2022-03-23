import Vue from 'vue'
import Vuex from 'vuex'
// import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        baseUrl: '',
        
        selectedVehicle: null
    },
    
    mutations: {
        setApiUrl: (state, payload) => {
            state.baseUrl = payload
            localStorage.setItem('apiUrl', payload)
        },
        
        setSelectedVehicle: (state, payload) => {{state.selectedVehicle = payload}}
    },
    actions: {},
    modules: {}
})