<template>
    <div>
        <b-row class="align-items-center vh-100 m-0 ">
            <b-col class="d-flex justify-content-center vw-100">
                <b-card class="w-25">
                    <b-row>
                        <B-col>
                            <div class="d-flex justify-content-between align-items-center">
                                <h4 class="m-0">Edit Driver</h4>
                                <b-button variant="outline-red" squared @click="openDeleteModal" size="sm">Delete</b-button>
                            </div>
                        </B-col>
                    </b-row>
                    <B-form>
                        <b-row>
                            <b-col>
                                <label>Name</label>
                                <b-form-input v-model="selectedDriver.name"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Surname</label>
                                <b-form-input v-model="selectedDriver.surname"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Location</label>
                                <b-input-group-append>
                                    <b-form-input disabled v-model="selectedDriver.location"></b-form-input>
                                    <b-input-group-append>
                                        <b-button text="Button" variant="outline-primary" @click="openSearchModal" >Search</b-button>
                                    </b-input-group-append>
                                </b-input-group-append>
                            </b-col>
                        </b-row>
                        <hr class="mx-3" />
                        <b-row>
                            <b-col>
                                <label>License</label>
                            </b-col>
                        </b-row>
                        <b-row class="justify-content-center">
                            <b-row>
                                <b-col>
                                    <b-button
                                        pill
                                        v-model="selectedDriver.codeA"
                                        :variant="ACode"
                                        :pressed.sync="selectedDriver.codeA"
                                        @click="toggleButtonCodeA"
                                    >Code A: {{selectedDriver.codeA ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="selectedDriver.codeA1"
                                        :variant="A1Code"
                                        :pressed.sync="selectedDriver.codeA1"
                                        @click="toggleButtonCodeA1"
                                        class="ml-2"
                                    >Code A1: {{selectedDriver.codeA1 ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="selectedDriver.codeB"
                                        :variant="BCode"
                                        :pressed.sync="selectedDriver.codeB"
                                        @click="toggleButtonCodeB"
                                        class="ml-2"
                                    >Code B: {{selectedDriver.codeB ? 'Yes' : 'No'}}</b-button>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col>
                                    <b-button
                                        pill
                                        v-model="selectedDriver.codeC1"
                                        :variant="C1Code"
                                        :pressed.sync="selectedDriver.codeC1"
                                        @click="toggleButtonCodeC1"
                                        class="ml-2"
                                    >Code C1: {{selectedDriver.codeC1 ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="selectedDriver.codeC"
                                        :variant="CCode"
                                        :pressed.sync="selectedDriver.codeC"
                                        @click="toggleButtonCodeC"
                                        class="ml-2"
                                    >Code C: {{selectedDriver.codeC ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="selectedDriver.codeEB"
                                        :variant="EBCode"
                                        :pressed.sync="selectedDriver.codeEB"
                                        @click="toggleButtonCodeEB"
                                        class="ml-2"
                                    >Code EB: {{selectedDriver.codeEB ? 'Yes' : 'No'}}</b-button>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col>
                                    <b-button
                                        pill
                                        v-model="selectedDriver.codeEC1"
                                        :variant="EC1Code"
                                        :pressed.sync="selectedDriver.codeEC1"
                                        @click="toggleButtonCodeEC1"
                                        class="ml-2"
                                    >Code EC1: {{selectedDriver.codeEC1 ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="selectedDriver.codeEC"
                                        :variant="ECCode"
                                        :pressed.sync="selectedDriver.codeEC"
                                        @click="toggleButtonCodeEC"
                                        class="ml-2"
                                    >Code EC: {{selectedDriver.codeEC ? 'Yes' : 'No'}}</b-button>
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
                                        <b-button variant="primary" squared @click="updateDriverDetails" class="ml-2">Update</b-button>
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

        <b-modal id="driverDeleteModal" hide-footer hide-header-close class="text-center" title="Delete Driver">
            <b-row>
                <b-col cols="12">
                    <label class="text-center">Are you sure you want to delete <span class="font-weight-bold text-red text-center">{{this.selectedDriver.name}} {{this.selectedDriver.surname}}</span>?</label>
                </b-col>
            </b-row>
            <b-row>
                <b-col cols="12" class="text-center mt-3">
                    <b-button variant="outline-red" @click="hideDeleteModal" squared class="mr-2" >Cancel</b-button>
                    <b-button variant="red" @click="removeDriver" squared >Delete</b-button>
                </b-col>
            </b-row>
            <div class="d-block"></div>
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
        isCodeC1: false,
        isCodeEB: false,
        isCodeEC1: false,
        isCodeEC: false,
    }),
    beforeCreate() {
    },
    created() {
        this.getSelectedDriver()
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
        ...mapActions(['getDriverDetails', "getAllOffice", "updateDriver"]),
        
        goBack() {
            this.$router.back()
        },
        
        getSelectedDriver() {
            if (this.$store.state.selectedDriver == null){
                this.$router.back()
            }
            this.getDriverDetails()
            .then((response) => {
                this.$store.commit('setSelectedDriver', response.data)
                this.isCodeA = this.selectedDriver.codeA
                this.isCodeA1 = this.selectedDriver.codeA1
                this.isCodeB = this.selectedDriver.codeB
                this.isCodeC = this.selectedDriver.codeC
                this.isCodeC1 = this.selectedDriver.codeC1
                this.isCodeEB = this.selectedDriver.codeEB
                this.isCodeEC1 = this.selectedDriver.codeEC1
                this.isCodeEC = this.selectedDriver.codeEC
                console.log('EDIT DRIVER', response.data)
            })
        },

        loadOffice() {
            this.getAllOffice()
                .then(response => {
                    const that = this
                    that.officeTable.dataSource = response.data
                })
        },

        updateDriverDetails() {
            this.$store.commit('setSelectedDriver', this.selectedDriver)
            this.updateDriver()
            .then(() => {
                this.$router.back()
            })
        },


        openSearchModal() {
            this.$bvModal.show('officeSearchModal')
            this.loadOffice()
        },
        hideSearchModal() {
            this.$bvModal.hide('officeSearchModal')
        },
        addOffice(rowItem) {
            this.hideSearchModal()
            this.selectedDriver.location = rowItem.location
            this.selectedDriver.officeId = rowItem.officeId
            console.log("NEW OFFICE", rowItem)
        },

        openDeleteModal() {
            this.$bvModal.show('driverDeleteModal')
        },
        hideDeleteModal() {
            this.$bvModal.hide('driverDeleteModal')
        },
        removeDriver() {
            this.selectedDriver.isActive = false
            this.$store.commit('setSelectedDriver', this.selectedDriver)
            this.updateDriver()
                .then(() => {
                    this.$router.back()
                })
                .catch (() => {
                    this.state= 'show'
                })
        },

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
        toggleButtonCodeC1() {
            this.isCodeC1 = !this.isCodeC1
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
        ...mapState([
            "selectedDriver"
        ]),
        
        ACode() {
            return this.isCodeA ? "primary" : "light"
        },
        A1Code() {
            return this.isCodeA1 ? "primary" : "light"
        },
        BCode() {
            return this.isCodeB ? "primary" : "light"
        },
        CCode() {
            return this.isCodeC ? "primary" : "light"
        },
        C1Code() {
            return this.isCodeC1 ? "primary" : "light"
        },
        EBCode() {
            return this.isCodeEB ? "primary" : "light"
        },
        EC1Code() {
            return this.isCodeEC1 ? "primary" : "light"
        },
        ECCode() {
            return this.isCodeEC ? "primary" : "light"
        },
        rows() {
            return this.officeTable.dataSource.length
        },
    },
}
</script>

<style scoped>

</style>