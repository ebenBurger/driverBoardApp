<template>
    <div>
        <b-row class="align-items-center vh-100 m-0 ">
            <b-col class="d-flex justify-content-center vw-100">
                <b-card class="w-25">
                    <b-row>
                        <B-col>
                            <h4>Add Vehicle</h4>
                        </B-col>
                    </b-row>
                    <B-form>
                        <b-row>
                            <b-col>
                                <label>Make</label>
                                <b-form-input v-model="vehicleValues.makeVehicle"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Model</label>
                                <b-form-input v-model="vehicleValues.modelVehicle"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Location</label>
                                <b-form-select v-model="selectedOffice">
                                    <b-form-select-option v-for="(item, index) in locations" :key="index" :value="item">{{item.location}}</b-form-select-option>
                                </b-form-select>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Odometer</label>
                                <b-form-input v-model="vehicleValues.odometer"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Model Year</label>
                                <b-form-input v-model="vehicleValues.year"></b-form-input>
                            </b-col>
                        </b-row>
                        <hr class="mx-3">
                        <b-row>
                            <b-col>
                                <div class="d-flex justify-content-end">
                                    <div>
                                        <b-button variant="outline-red" squared @click="goBack" class="ml-2">Cancel</b-button>
                                    </div>
                                    <div>
                                        <b-button variant="primary" squared @click="save" class="ml-2">Save</b-button>
                                    </div>
                                </div>
                            </b-col>
                        </b-row>
                    </B-form>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>

<script>
import {mapActions} from "vuex";

export default {
    data: () => ({
        vehicleValues: {
            modelVehicle: null,
            makeVehicle: null,
            location: null,
            odometer: null,
            isActive: true,
            isAvailable: true,
            year: null,
            officeId: null,
        },
        locations: [],
        selectedOffice: [],
    }),
    beforeCreate() {
    },
    created() {
        this.loadOffice()
    },
    beforeMount() {
    },
    mounted() {
    },
    beforeUpdate() {
    },
    updated() {
    },
    methods: {
        ...mapActions(['createNewVehicle', "getAllOffice"]),
        
        goBack(){
            this.$router.back()
        },
        
        loadOffice() {
            this.getAllOffice()
            .then(response => {
                this.locations = response.data
            })
        },
        
        save(){
            this.vehicleValues.officeId = this.selectedOffice.officeId
            this.vehicleValues.location = this.selectedOffice.location
            this.$store.commit('setVehicleCreateRequest', this.vehicleValues)
            this.state = 'loading'
            this.createNewVehicle()
            .then(() => {
                this.goBack()
            })
            .catch((err) => {
                this.state = 'show'
                console.log('ERROR', err)
            })
        },
    },
    computed: {},
}
</script>

<style scoped>

</style>