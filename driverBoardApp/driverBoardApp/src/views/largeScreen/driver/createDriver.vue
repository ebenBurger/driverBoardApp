<template>
    <div>
        <b-row class="align-items-center vh-100 m-0 ">
            <b-col class="d-flex justify-content-center vw-100">
                <b-card class="w-25">
                    <b-row>
                        <B-col>
                            <h4>Add Driver</h4>
                        </B-col>
                    </b-row>
                    <B-form>
                        <b-row>
                            <b-col>
                                <label>Name</label>
                                <b-form-input v-model="driverData.name"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Surname</label>
                                <b-form-input v-model="driverData.surname"></b-form-input>
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
                                <label>Vehicle</label>
<!--                                <b-form-group v-slot="{ariaDescribedby}">-->
<!--                                    <b-form-checkbox-group-->
<!--                                        id="checkBox"-->
<!--                                        v-model="driverData.vehicle"-->
<!--                                        :aria-describedby="ariaDescribedby"-->
<!--                                        name="vehicleList">-->
<!--                                    </b-form-checkbox-group>-->
<!--                                    <b-form-checkbox v-for="(value, index) in vehicles" :key='index'>{{index}} - {{value.makeVehicle}}</b-form-checkbox>-->
<!--                                </b-form-group>-->
<!--                                <b-form-select v-model="selectedOffice">-->
<!--                                    <b-form-select-option v-for="(item, index) in locations" :key="index" :value="item">{{item.location}}</b-form-select-option>-->
<!--                                </b-form-select>-->
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
        driverData: {
            name: null,
            surname: null,
            location: null,
            vehicle: {},
        },
        vehicles: [],
        locations: [],
        selectedOffice: [],
        selectedVehicle: [],
    }),
    beforeCreate() {
    },
    created() {
        this.listVehicle()
        this.loadOffice()
    },
    beforeMount() {
    },
    mounted() {
    },
    beforeUpdate() {
    },
    updated() {
        console.log("SELETED", this.selectedVehicle)
    },
    methods: {
        ...mapActions(["createNewDriver", "getAllVehiclesRequest", "getAllOffice"]),
        goBack() {
            this.$router.back()
        },
        listVehicle() {
            this.getAllVehiclesRequest()
            .then((response) => {
                this.vehicles = response.data
                console.log('VEHICLES DATA', this.vehicles)
            })
        },
        loadOffice() {
            this.getAllOffice()
                .then(response => {
                    this.locations = response.data
                    console.log('OFFICE', this.locations)
                })
        },
        save() {
            this.driverData.location = this.selectedOffice.location
            this.driverData.vehicle = this.selectedVehicle.vehicleId
            this.$store.commit('setCreateDriverRequest', this.driverData)
            this.createNewDriver()
            .then(() => {
                this.goBack()
                console.log("DRIVER", this.driverData)
            })
            
        },
    },
    computed: {},
}
</script>

<style scoped>

</style>