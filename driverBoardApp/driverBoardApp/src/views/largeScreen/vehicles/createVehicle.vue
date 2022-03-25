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
                                <b-form-input v-model="vehicleValues.make"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Model</label>
                                <b-form-input v-model="vehicleValues.model"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Location</label>
                                <b-form-input v-model="vehicleValues.location"></b-form-input>
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
            model: null,
            make: null,
            location: null,
            
        }
    }),
    beforeCreate() {
    },
    created() {
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
        ...mapActions(['createNewVehicle']),
        
        goBack(){
            this.$router.back()
        },
        
        save(){
            const request = {
                modelVehicle: this.vehicleValues.model,
                makeVehicle: this.vehicleValues.make,
                location: this.vehicleValues.location,
                isActive: true,
            }
            
            this.$store.commit('setVehicleCreateRequest', request)
            this.state = 'loading'
            this.createNewVehicle()
            .then(() => {
                this.goBack()
            })
            .catch(() => {
                this.state = 'show'
            })
        },
    },
    computed: {},
}
</script>

<style scoped>

</style>