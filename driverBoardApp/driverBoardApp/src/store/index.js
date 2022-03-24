import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        baseUrl: '',
        
        //selected
        
        //requests and initial states
        vehicleRequest: null,
        vehicleCreateRequest: null,
    },
    
    mutations: {
        setApiUrl: (state, payload) => {
            state.baseUrl = payload
            localStorage.setItem('apiUrl', payload)
        },
        
        setVehicleRequest: (state, payload) => {state.vehicleRequest = payload},
        setVehicleCreateRequest: (state, payload) => {state.vehicleCreateRequest = payload},
        
    },
    actions: {
        //vehicles
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
        },
        createNewVehicle: ({state}) => {
            let payload = state.vehicleCreateRequest
            
            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'post',
                    url: state.baseUrl + 'Vehicle/Save',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    data: payload
                }
                
                axios(callConfig)
                .then(response => {
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