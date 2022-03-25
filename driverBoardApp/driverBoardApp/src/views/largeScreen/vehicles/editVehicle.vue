<template>
    <div>
        <b-row>
            <b-col>
                <b-card>
                    <b-row>
                        <B-col>
                            <div class="d-flex justify-content-between align-items-center">
                                <h4 class="m-0">Contact View</h4>
                                <b-button variant="outline-red" squared @click="openModal" size="sm">Delete</b-button>
                            </div>
                        </B-col>
                    </b-row>
                    <B-form>
                        <b-row>
                            <b-col cols="4">
                                <label>Make</label>
                                <b-form-input v-model="selectedVehicle.makeVehicle"></b-form-input>
                            </b-col>
                            <b-col cols="4">
                                <label>Model</label>
                                <b-form-input v-model="selectedVehicle.modelVehicle"></b-form-input>
                            </b-col>
                            <b-col cols="4">
                                <label>Location</label>
                                <b-form-input v-model="selectedVehicle.location"></b-form-input>
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
                                        <b-button variant="primary" squared @click="updateVehicleDetails" class="ml-2">Update</b-button>
                                    </div>
                                </div>
                            </b-col>
                        </b-row>
                    </B-form>
                </b-card>
            </b-col>
        </b-row>

        <b-modal id="vehicleModal" hide-footer hide-header-close class="text-center" title="Delete Vehicle">
            <b-row>
                <b-col cols="12">
                    <label class="text-center">Are you sure you want to delete <span class="font-weight-bold text-red text-center">{{this.selectedVehicle.makeVehicle}} {{this.selectedVehicle.modelVehicle}}</span>?</label>
                </b-col>
            </b-row>
            <b-row>
                <b-col cols="12" class="text-center mt-3">
                    <b-button variant="outline-red" @click="hideModal" squared class="mr-2" >Cancel</b-button>
                    <b-button variant="red" @click="removeVehicle" squared >Delete</b-button>
                </b-col>
            </b-row>
            <div class="d-block"></div>
        </b-modal>
        
    </div>
</template>

<script>
import {mapActions, mapState} from "vuex";

export default {
    data: () => ({}),
    beforeCreate() {
    },
    created() {
        this.getSelectedVehicle()
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
        ...mapActions(['getVehicleDetails', 'updateVehicle']),
        
        goBack() {
            this.$router.back()
        },
        
        save() {},
        
        getSelectedVehicle() {
            if (this.$store.state.selectedVehicle == null) {
                this.$router.push({path: '/'})
            }
            this.getVehicleDetails()
            .then((response) => {
                this.$store.commit('setSelectedVehicle', response.data)
                console.log("DATA", response.data)
            })
        },
        updateVehicleDetails() {
            console.log("VEHICLE UPDATED", this.selectedVehicle)
            
            const vehicleDetailUpdated = {}
            vehicleDetailUpdated.Id = this.selectedVehicle.id
            vehicleDetailUpdated.modelVehicle = this.selectedVehicle.modelVehicle
            vehicleDetailUpdated.makeVehicle = this.selectedVehicle.makeVehicle
            vehicleDetailUpdated.location = this.selectedVehicle.location
            vehicleDetailUpdated.isActive = true
            
            this.$store.commit('setSelectedVehicle', vehicleDetailUpdated)
            this.updateVehicle()
            .then(() => {
                this.$router.back()
            })
            .catch (() => {
                this.state= 'show'
            })
        },
        
        openModal() {
            this.$bvModal.show('vehicleModal')
        },
        hideModal() {
            this.$bvModal.hide('vehicleModal')
        },
        removeVehicle() {
            console.log("VEHICLE UPDATED", this.selectedVehicle)

            const vehicleDetailUpdated = {}
            vehicleDetailUpdated.Id = this.selectedVehicle.id
            vehicleDetailUpdated.modelVehicle = this.selectedVehicle.modelVehicle
            vehicleDetailUpdated.makeVehicle = this.selectedVehicle.makeVehicle
            vehicleDetailUpdated.location = this.selectedVehicle.location
            vehicleDetailUpdated.isActive = false

            this.$store.commit('setSelectedVehicle', vehicleDetailUpdated)
            this.updateVehicle()
                .then(() => {
                    this.$router.back()
                })
                .catch (() => {
                    this.state= 'show'
                })
        },
    },
    computed: {
        ...mapState([
            "selectedVehicle"
        ])
    },
}
</script>

<style scoped>

</style>