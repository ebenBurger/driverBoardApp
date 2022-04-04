import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        baseUrl: '',
        
        //selected- view data.
        selectedVehicle: null,
        
        //requests and initial states
        
        //address
        addressBookRequest: null,
        addressBookCreateRequest: null,
        
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
        
        //address Book
        setAddressBookRequest: (state, payload) => {state.addressBookRequest = payload},
        setAddressBookCreateRequest: (state, payload) => {state.addressBookCreateRequest = payload},
        
        //office
        setOfficeRequest: (state, payload) => {state.officeRequest = payload},
        setOfficeCreateRequest: (state, payload) => {state.officeCreateRequest = payload},
        
        //vehicle
        setVehicleRequest: (state, payload) => {state.vehicleRequest = payload},
        setVehicleCreateRequest: (state, payload) => {state.vehicleCreateRequest = payload},
        setSelectedVehicle: (state, payload) => {state.selectedVehicle = payload},
        
        //driver
        setDriverRequest: (state, payload) => {state.driverRequest = payload},
        setCreateDriverRequest: (state, payload) => {state.createDriverRequest = payload},

        //contacts
        setContactRequest: (state, payload) => {state.contactRequest = payload},
        setCreateContactRequest: (state, payload) => {state.createContactRequest = payload},
        
    },
    actions: {
        //address book
        getAllAddressBook: ({state}) => {
          return  new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'AddressBook/GetAll',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
                axios(callConfig)
                    .then(response => {
                        state.addressBookDeatil = response.data
                        resolve(response)
                    })
                    .catch(err => {
                        reject(err)
                    })
            })
        },
        createNewAddressBook: ({state}) => {
            let payload = state.addressBookCreateRequest

            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'post',
                    url: state.baseUrl + 'AddressBook/Save',
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
        
        //vehicles
        getAllVehiclesRequest: ({state}) => {
            return new Promise((resolve, reject) => {
                const callConfig = {
                    method: 'get',
                    url: state.baseUrl + 'Vehicle/GetAll',
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
                
                axios(callConfig)
                    .then(response => {
                        state.vehicleDetail = response.data
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
                        state.vehicle = response.data
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
    },
    modules: {}
})