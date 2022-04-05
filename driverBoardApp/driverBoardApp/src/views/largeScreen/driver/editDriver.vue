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
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col>
                                    <b-button
                                        pill
                                        v-model="selectedDriver.codeB"
                                        :variant="BCode"
                                        :pressed.sync="selectedDriver.codeB"
                                        @click="toggleButtonCodeB"
                                        class="ml-2"
                                    >Code B: {{selectedDriver.codeB ? 'Yes' : 'No'}}</b-button>
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
        ...mapActions(['getDriverDetails', "getAllOffice", "updateDriver"]),
        
        goBack() {
            this.$router.back()
        },

        loadOffice() {
            this.getAllOffice()
                .then(response => {
                    this.officeTable.dataSource = response.data
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
            this.selectedDriver.isCodeA = !this.selectedDriver.isCodeA
        },
        toggleButtonCodeA1() {
            this.selectedDriver.isCodeA1 = !this.selectedDriver.isCodeA1
        },
        toggleButtonCodeB() {
            this.selectedDriver.isCodeB = !this.selectedDriver.isCodeB
        },
        toggleButtonCodeC() {
            this.selectedDriver.isCodeC = !this.selectedDriver.isCodeC
        },
        toggleButtonCodeEB() {
            this.selectedDriver.isCodeEB = !this.selectedDriver.isCodeEB
        },
        toggleButtonCodeEC1() {
            this.selectedDriver.isCodeEC1 = !this.selectedDriver.isCodeEC1
        },
        toggleButtonCodeEC() {
            this.selectedDriver.isCodeEC = !this.selectedDriver.isCodeEC
        },
    },
    computed: {
        ...mapState([
            "selectedDriver"
        ]),
        ACode() {
            return this.selectedDriver.isCodeA? "primary" : "light"
        },
        A1Code() {
            return this.selectedDriver.isCodeA1? "primary" : "light"
        },
        BCode() {
            return this.selectedDriver.isCodeB? "primary" : "light"
        },
        CCode() {
            return this.selectedDriver.isCodeC? "primary" : "light"
        },
        EBCode() {
            return this.selectedDriver.isCodeEB? "primary" : "light"
        },
        EC1Code() {
            return this.selectedDriver.isCodeEC1? "primary" : "light"
        },
        ECCode() {
            return this.selectedDriver.isCodeEC? "primary" : "light"
        },
        rows() {
            return this.officeTable.dataSource.length
        },
    },
}
</script>

<style scoped>

</style>