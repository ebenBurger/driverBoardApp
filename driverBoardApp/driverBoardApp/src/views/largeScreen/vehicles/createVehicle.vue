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
                                <b-input-group-append>
                                    <b-form-input disabled v-model="vehicleValues.location"></b-form-input>
                                    <b-input-group-append>
                                        <b-button text="Button" variant="outline-primary" @click="openSearchModal" >Search</b-button>
                                    </b-input-group-append>
                                </b-input-group-append>
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
                                <h6 class="text-primary text-center">License <span class="text-danger font-weight-bold">REQUIRED</span> to drive vehicle</h6>
                            </b-col>
                        </b-row>
                        <b-row class="justify-content-center">
                            <b-row>
                                <b-col>
                                    <b-button
                                        pill
                                        v-model="vehicleValues.codeA"
                                        :variant="ACode"
                                        :pressed.sync="vehicleValues.codeA"
                                        @click="toggleButtonCodeA"
                                    >Code A: {{vehicleValues.codeA ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="vehicleValues.codeA1"
                                        :variant="A1Code"
                                        :pressed.sync="vehicleValues.codeA1"
                                        @click="toggleButtonCodeA1"
                                        class="ml-2"
                                    >Code A1: {{vehicleValues.codeA1 ? 'Yes' : 'No'}}</b-button>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col>
                                    <b-button
                                        pill
                                        v-model="vehicleValues.codeB"
                                        :variant="BCode"
                                        :pressed.sync="vehicleValues.codeB"
                                        @click="toggleButtonCodeB"
                                        class="ml-2"
                                    >Code B: {{vehicleValues.codeB ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="vehicleValues.codeC"
                                        :variant="CCode"
                                        :pressed.sync="vehicleValues.codeC"
                                        @click="toggleButtonCodeC"
                                        class="ml-2"
                                    >Code C: {{vehicleValues.codeC ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="vehicleValues.codeEB"
                                        :variant="EBCode"
                                        :pressed.sync="vehicleValues.codeEB"
                                        @click="toggleButtonCodeEB"
                                        class="ml-2"
                                    >Code EB: {{vehicleValues.codeEB ? 'Yes' : 'No'}}</b-button>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col>
                                    <b-button
                                        pill
                                        v-model="vehicleValues.codeEC1"
                                        :variant="EC1Code"
                                        :pressed.sync="vehicleValues.codeEC1"
                                        @click="toggleButtonCodeEC1"
                                        class="ml-2"
                                    >Code EC1: {{vehicleValues.codeEC1 ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="vehicleValues.codeEC"
                                        :variant="ECCode"
                                        :pressed.sync="vehicleValues.codeEC"
                                        @click="toggleButtonCodeEC"
                                        class="ml-2"
                                    >Code EC: {{vehicleValues.codeEC ? 'Yes' : 'No'}}</b-button>
                                </b-col>
                            </b-row>
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
import {mapActions} from "vuex";

export default {
    data: () => ({
        vehicleValues: {
            modelVehicle: null,
            makeVehicle: null,
            odometer: null,
            year: null,
            isActive: true,
            isAvailable: true,
            officeId: null,
            location: null,
            codeA: false,
            codeA1: false,
            codeB: false,
            codeC: false,
            codeEB: false,
            codeEC1: false,
            codeEC: false,
        },
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
                    this.officeTable.dataSource = response.data
                })
        },

        openSearchModal() {
            this.$bvModal.show('officeSearchModal')
        },
        hideSearchModal() {
            this.$bvModal.hide('officeSearchModal')
        },
        addOffice(rowItem) {
            this.hideSearchModal()
            this.vehicleValues.location = rowItem.location
            this.vehicleValues.officeId = rowItem.officeId
            console.log('ROW ITEM', rowItem)
        },
        
        save(){
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

        //toggle license classes
        toggleButtonCodeA() {
            this.isCodeA = !this.isCodeA
        },
        toggleButtonCodeA1() {
            this.isCodeA1 = !this.isCodeA1
        },
        toggleButtonCodeB() {
            this.isCodeB = !this.isCodeB
        },
        toggleButtonCodeC() {
            this.isCodeC = !this.isCodeC
        },
        toggleButtonCodeEB() {
            this.isCodeEB = !this.isCodeEB
        },
        toggleButtonCodeEC1() {
            this.isCodeEC1 = !this.isCodeEC1
        },
        toggleButtonCodeEC() {
            this.isCodeEC = !this.isCodeEC
        },
    },
    computed: {
        ACode() {
            return this.isCodeA? "primary" : "light"
        },
        A1Code() {
            return this.isCodeA1? "primary" : "light"
        },
        BCode() {
            return this.isCodeB? "primary" : "light"
        },
        CCode() {
            return this.isCodeC? "primary" : "light"
        },
        EBCode() {
            return this.isCodeEB? "primary" : "light"
        },
        EC1Code() {
            return this.isCodeEC1? "primary" : "light"
        },
        ECCode() {
            return this.isCodeEC? "primary" : "light"
        },
        rows() {
            return this.officeTable.dataSource.length
        },
    },
}
</script>

<style scoped>

</style>