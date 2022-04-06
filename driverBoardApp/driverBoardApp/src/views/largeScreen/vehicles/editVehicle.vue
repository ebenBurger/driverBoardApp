<template>
    <div>
        <b-row class="align-items-center vh-100 m-0 ">
            <b-col class="d-flex justify-content-center vw-100">
                <b-card class="w-25">
                    <b-row>
                        <B-col>
                            <div class="d-flex justify-content-between align-items-center">
                                <h4 class="m-0">Edit Vehicle</h4>
                                <b-button variant="outline-red" squared @click="openDeleteModal" size="sm">Delete</b-button>
                            </div>
                        </B-col>
                    </b-row>
                    <B-form>
                        <b-row>
                            <b-col class="text-center my-3">This vehicle 
                                <span class="text-danger">REQUIRES </span> a 
                                <span class="badge-primary p-1" v-if="selectedVehicle.codeA">Code A</span>
                                <span class="badge-primary p-1" v-if="selectedVehicle.codeA1">Code A1</span>
                                <span class="badge-primary p-1" v-if="selectedVehicle.codeB">Code B</span>
                                <span class="badge-primary p-1" v-if="selectedVehicle.codeC">Code C</span>
                                <span class="badge-primary p-1" v-if="selectedVehicle.codeC1">Code C1</span>
                                <span class="badge-primary p-1" v-if="selectedVehicle.codeEB">Code EB</span>
                                <span class="badge-primary p-1" v-if="selectedVehicle.codeEC1">Code EC1</span>
                                <span class="badge-primary p-1" v-if="selectedVehicle.codeEC">Code EC</span>
                                
                                license
                            </b-col>
                            
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Make</label>
                                <b-form-input disabled v-model="selectedVehicle.makeVehicle"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Model</label>
                                <b-form-input disabled v-model="selectedVehicle.modelVehicle"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Location</label>
                                <b-input-group-append>
                                    <b-form-input disabled v-model="selectedVehicle.location"></b-form-input>
                                    <b-input-group-append>
                                        <b-button text="Button" variant="outline-primary" @click="openSearchModal" >Search</b-button>
                                    </b-input-group-append>
                                </b-input-group-append>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Odometer</label>
                                <b-form-input v-model="selectedVehicle.odometer"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Model Year</label>
                                <b-form-input disabled v-model="selectedVehicle.year"></b-form-input>
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
                                        <b-button variant="primary" squared @click="updateVehicleDetails" class="ml-2">Save</b-button>
                                    </div>
                                </div>
                            </b-col>
                        </b-row>
                    </B-form>
                </b-card>
            </b-col>
        </b-row>

        <b-modal id="vehicleDeleteModal" hide-footer hide-header-close class="text-center" title="Delete Vehicle">
            <b-row>
                <b-col cols="12">
                    <label class="text-center">Are you sure you want to delete <span class="font-weight-bold text-red text-center">{{this.selectedVehicle.makeVehicle}} {{this.selectedVehicle.modelVehicle}}</span>?</label>
                </b-col>
            </b-row>
            <b-row>
                <b-col cols="12" class="text-center mt-3">
                    <b-button variant="outline-red" @click="hideDeleteModal" squared class="mr-2" >Cancel</b-button>
                    <b-button variant="red" @click="removeVehicle" squared >Delete</b-button>
                </b-col>
            </b-row>
            <div class="d-block"></div>
        </b-modal>

        <b-modal id="officeSearchModal" hide-footer size="xl" title="Atrax Office Search" @close="hideSearchModal">
<!--            <label>Office Search</label>-->
            <div class="d-flex w-100 mb-4">
<!--                <div class="w-50 h-auto">-->
<!--                    <b-form-input v-model="frontHarvestSearch.front" @keyup="filterFronts"></b-form-input>-->
<!--                    <b-form-input ></b-form-input>-->
<!--                </div>-->
<!--                <div class="w-50 h-auto">-->
<!--                    <div class="d-flex justify-content-end ">-->
<!--                        <b-button variant="outline-danger" class="mr-2">Clear</b-button>-->
<!--                        <b-button variant="outline-primary" class="mr-2" >Search</b-button>-->
<!--                    </div>-->
<!--                </div>-->
            </div>
            <div>
                <b-table striped hover
                         :items="officeTable.dataSource"
                         :fields="officeTable.tableColumns"
                         :busy="officeTable.isLoading"
                         @row-clicked="addOffice"
                         :per-page="officeTable.resultsPerPage"
                         id="stockTable"
                         :current-page="officeTable.currentPage">

                    <template #table-busy>
                        <div class="text-center my-2">
                            <b-spinner style="width: 3rem; height: 3rem;"></b-spinner>
                        </div>
                    </template>

                    <template #cell(actions)="row">
                        <b-row align-v="center" align-h="end">
                            <b-button size="sm" class="btn-icon" @click="addOffice(row.item)">
                                <b-icon-chevron-right></b-icon-chevron-right>
                            </b-button>
                        </b-row>
                    </template>

                </b-table>
            </div>
            <div class="d-flex justify-content-center">
                <b-pagination
                    v-model="officeTable.currentPage"
                    :total-rows="rows"
                    :per-page="officeTable.resultsPerPage"
                    aria-controls="stockTable"
                ></b-pagination>
            </div>
            <div class="d-flex justify-content-end w-100">
                <b-button variant="outline-danger" class="mr-2" @click="hideSearchModal">Cancel</b-button>
            </div>
        </b-modal>
        
    </div>
</template>

<script>
import {mapActions, mapState} from "vuex";

export default {
    data: () => ({
        officeTable: {
            resultsPerPage: 10,
            currentPage: 1,
            dataSource: [],
            isLoading: false,
            tableColumns: [
                {
                    label: 'Office',
                    key: 'building',
                    sortable: true,
                    tdClass:'',
                },
                {
                    label: 'Address',
                    key: 'addressLine1',
                    sortable: true,
                    tdClass:'',
                },
                {
                    label: 'Location',
                    key: 'location',
                    sortable: true,
                    tdClass:'',
                },
                {
                    label: '',
                    key: 'actions',
                    sortable: false,
                    tdClass: ''
                },
            ]
        },
        isCodeA: false,
        isCodeA1: false,
        isCodeB: false,
        isCodeC: false,
        isCodeEB: false,
        isCodeEC1: false,
        isCodeEC: false,
    }),
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
        ...mapActions(['getVehicleDetails', 'updateVehicle', "getAllOffice"]),
        
        goBack() {
            this.$router.back()
        },
        
        getSelectedVehicle() {
            if (this.$store.state.selectedVehicle == null) {
                this.$router.back()
            }
            this.getVehicleDetails()
            .then((response) => {
                this.$store.commit('setSelectedVehicle', response.data)
                this.isCodeA = this.selectedVehicle.codeA
                this.isCodeA1 = this.selectedVehicle.codeA1
                this.isCodeB = this.selectedVehicle.codeB
                this.isCodeC = this.selectedVehicle.codeC
                this.isCodeEB = this.selectedVehicle.codeEB
                this.isCodeEC1 = this.selectedVehicle.codeEC1
                this.isCodeEC = this.selectedVehicle.codeEC
                console.log('EDIT VEHICLE', response.data)
            })
        },
        
        updateVehicleDetails() {
            
            this.$store.commit('setSelectedVehicle', this.selectedVehicle)
            this.updateVehicle()
            .then(() => {
                this.$router.back()
            })
            .catch (() => {
                this.state= 'show'
            })
        },

        loadOffice() {
            this.getAllOffice()
                .then(response => {
                    this.officeTable.dataSource = response.data
                })
        },
        
        openDeleteModal() {
            this.$bvModal.show('vehicleDeleteModal')
        },
        hideDeleteModal() {
            this.$bvModal.hide('vehicleDeleteModal')
        },
        removeVehicle() {
            this.selectedVehicle.isActive = false
            this.$store.commit('setSelectedVehicle', this.selectedVehicle)
            this.updateVehicle()
                .then(() => {
                    this.$router.back()
                })
                .catch (() => {
                    this.state= 'show'
                })
        },
        
        openSearchModal() {
            this.loadOffice()
            this.$bvModal.show('officeSearchModal')
        },
        hideSearchModal() {
            this.$bvModal.hide('officeSearchModal')
        },
        addOffice(rowItem) {
            this.hideSearchModal()
            this.selectedVehicle.location = rowItem.location
            this.selectedVehicle.officeId = rowItem.officeId
            console.log("NEW OFFICE", rowItem)
        },
        
    },
    computed: {
        ...mapState([
            "selectedVehicle"
        ]),
        rows() {
            return this.officeTable.dataSource.length
        },
    },
}
</script>

<style scoped>

</style>