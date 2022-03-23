import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        baseUrl: 'https://localhost:5001/',
        
        //selected
        
        //requests and initial states
        vehicleRequest: null,
    },
    
    mutations: {
        setApiUrl: (state, payload) => {
            state.baseUrl = payload
            localStorage.setItem('apiUrl', payload)
        },
        
        setVehicleRequest: (state, payload) => {state.vehicleRequest = payload}
        
    },
    actions: {
        getAllVehiclesRequest: ({state}) => {
            console.log('STATE', state)
            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'Vehicle/getAll',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
                
                axios(callConfig)
                    .then(response => {
                        console.log('STATE', state)
                        state.vehicleRequest = response.data
                        resolve(response)
                    })
                    .catch(err => {
                        reject(err)
                    })
            })
        }
    },
    modules: {}
})