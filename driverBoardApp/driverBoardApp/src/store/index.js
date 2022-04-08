import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        baseUrl: 'https://localhost:5001/',
        
        //selected- view data.
        selectedVehicle: null,
        selectedOffice: null,
        selectedDriver: null,
        selectedContact: null,
        
        //requests and initial states
        
        //login
        loginRequest: null,
        
        //office
        officeRequest: null,
        officeCreateRequest: null,
        
        //vehicle
        vehicleRequest: null,
        vehicleCreateRequest: null,
        
        //driver
        driverRequest: null,
        createDriverRequest: null,
        
        //contacts
        contactRequest: null,
        createContactRequest: null,
    },
    
    mutations: {
        setApiUrl: (state, payload) => {
            state.baseUrl = payload
            localStorage.setItem('apiUrl', payload)
        },
        //Login
        setLoginRequest: (state, payload) => {state.loginRequest = payload},
        
        //office
        setOfficeRequest: (state, payload) => {state.officeRequest = payload},
        setOfficeCreateRequest: (state, payload) => {state.officeCreateRequest = payload},
        setSelectedOffice: (state, payload) => {state.selectedOffice = payload},
        
        //vehicle
        setVehicleRequest: (state, payload) => {state.vehicleRequest = payload},
        setVehicleCreateRequest: (state, payload) => {state.vehicleCreateRequest = payload},
        setSelectedVehicle: (state, payload) => {state.selectedVehicle = payload},
        
        //driver
        setDriverRequest: (state, payload) => {state.driverRequest = payload},
        setCreateDriverRequest: (state, payload) => {state.createDriverRequest = payload},
        setSelectedDriver: (state, payload) => {state.selectedDriver = payload},

        //contacts
        setContactRequest: (state, payload) => {state.contactRequest = payload},
        setCreateContactRequest: (state, payload) => {state.createContactRequest = payload},
        setSelectedContact: (state, payload) => {state.selectedContact = payload},
        
    },
    actions: {
        //login
        login: ({state}) => {
          const payload = state.loginRequest
            return new Promise((resolve, reject) =>{
                axios.post(state.baseUrl + 'Authentication/login', payload)
                    .then(response => {
                        localStorage.setItem('jwt', response.data.token)
                        resolve(response)
                    })
                    .catch((err) => {
                        reject()
                        console.log('ERROR', err)
                    })
            })
        },
        
        //Office
        getAllOffice: ({state}) => {
            return  new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'Office/GetAll',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
                axios(callConfig)
                    .then(response => {
                        state.OfficeDeatil = response.data
                        resolve(response)
                    })
                    .catch(err => {
                        reject(err)
                    })
            })
        },
        createNewOffice: ({state}) => {
            let payload = state.officeCreateRequest

            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'post',
                    url: state.baseUrl + 'Office/Save',
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
        },
        getOfficeDetails: ({state}) => {
            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'Office/Get/' + state.selectedOffice.officeId,
                    headers: {},
                }
                axios(callConfig)
                    .then(response => {
                        state.setSelectedOffice = response.data
                        resolve(response)
                    })
                    .catch( err => {
                        reject(err)
                    })
            })
        },
        updateOffice: ({state}) => {
            const payload = state.selectedOffice

            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'post',
                    url: state.baseUrl + 'Office/Update',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    data: payload,
                }

                axios(callConfig)
                    .then(response => {
                        resolve(response)
                    })
                    .catch(err => {
                        reject(err)
                    })
            })
        },
        
        //vehicles
        getAllVehiclesRequest: ({state}) => {
            console.log("JWT", localStorage.getItem('jwt'))
            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'Vehicle',
                    headers: {
                        'Authorization': localStorage.getItem('jwt'),
                        'Content-Type': 'application/json'
                    },
                }
                
                axios(callConfig)
                    .then(response => {
                        state.vehicleDetail = response.data
                        resolve(response)
                    })
                    .catch(err => {
                        console.log('Error', err)
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
        },
        getVehicleDetails: ({state}) => {
            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'Vehicle/get/' + state.selectedVehicle.vehicleId,
                    headers: {},
                }
                axios(callConfig)
                    .then(response => {
                        state.setSelectedVehicle = response.data
                        resolve(response)
                    })
                    .catch( err => {
                        reject(err)
                    })
            })
        },
        updateVehicle: ({state}) => {
            const payload = state.selectedVehicle
            
            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'post',
                    url: state.baseUrl + 'Vehicle/Update',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    data: payload,
                }
                
                axios(callConfig)
                    .then(response => {
                        resolve(response)
                    })
                    .catch(err => {
                        reject(err)
                    })
            })
        },
        
        //Driver
        getAllDriver: ({state}) => {
            return  new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'Driver/GetAll',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
                axios(callConfig)
                    .then(response => {
                        state.driverRequest = response.data
                        resolve(response)
                    })
                    .catch(err => {
                        reject(err)
                    })
            })
        },
        createNewDriver: ({state}) => {
            let payload = state.createDriverRequest

            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'post',
                    url: state.baseUrl + 'Driver/Save',
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
        },
        getDriverDetails: ({state}) => {
            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'Driver/Get/' + state.selectedDriver.driverId,
                    headers: {},
                }
                axios(callConfig)
                    .then(response => {
                        state.setSelectedDriver = response.data
                        resolve(response)
                    })
                    .catch( err => {
                        reject(err)
                    })
            })
        },
        updateDriver: ({state}) => {
            const payload = state.selectedDriver

            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'post',
                    url: state.baseUrl + 'Driver/Update',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    data: payload,
                }

                axios(callConfig)
                    .then(response => {
                        resolve(response)
                    })
                    .catch(err => {
                        reject(err)
                    })
            })
        },

        //Contacts
        getAllContact: ({state}) => {
            return  new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'Contact/GetAll',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
                axios(callConfig)
                    .then(response => {
                        state.contactRequest = response.data
                        resolve(response)
                    })
                    .catch(err => {
                        reject(err)
                    })
            })
        },
        createNewContact: ({state}) => {
            let payload = state.createContactRequest

            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'post',
                    url: state.baseUrl + 'Contact/Save',
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
        },
        getContactDetails: ({state}) => {
            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'Contact/Get/' + state.selectedContact.contactId,
                    headers: {},
                }
                axios(callConfig)
                    .then(response => {
                        state.setSelectedContact = response.data
                        resolve(response)
                    })
                    .catch( err => {
                        reject(err)
                    })
            })
        },
        updateContact: ({state}) => {
            const payload = state.selectedContact

            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'post',
                    url: state.baseUrl + 'Contact/Update',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    data: payload,
                }

                axios(callConfig)
                    .then(response => {
                        resolve(response)
                    })
                    .catch(err => {
                        reject(err)
                    })
            })
        },
    },
    modules: {}
})