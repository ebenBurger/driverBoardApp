<template>
    <div>
        <b-row class="align-items-center vh-100 m-0 ">
            <b-col class="d-flex justify-content-center vw-100">
                <b-card class="w-50">
                    <b-row>
                        <B-col>
                            <h4>Add Contact</h4>
                        </B-col>
                    </b-row>
                    <B-form>
                        <label class="text-primary font-weight-bold mb-4">Personal Details</label>
                        <b-row>
                            <b-col>
                                <label>Name</label>
                                <b-form-input v-model="contactData.name"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Surname</label>
                                <b-form-input v-model="contactData.surname"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Mobile Number</label>
                                <b-form-input v-model="contactData.mobile"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Landline</label>
                                <b-form-input v-model="contactData.landline"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col cols="6">
                                <label>Email</label>
                                <b-form-input v-model="contactData.email"></b-form-input>
                            </b-col>
                        </b-row>
                        <hr class="mx-3">
                        <label class="text-primary font-weight-bold mb-4">Company Details</label>
                        <b-row>
                            <b-col>
                                <label>Company Name</label>
                                <b-form-input v-model="contactData.companyName"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Location</label>
                                <b-input-group-append>
                                    <b-form-input disabled v-model="contactData.location"></b-form-input>
                                    <b-input-group-append>
                                        <b-button text="Button" variant="outline-primary" @click="openSearchModal" >Search</b-button>
                                    </b-input-group-append>
                                </b-input-group-append>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Building</label>
                                <b-form-input v-model="contactData.building"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Office Park</label>
                                <b-form-input v-model="contactData.officePark"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Address Line 1</label>
                                <b-form-input v-model="contactData.addressLine1"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Address Line 2</label>
                                <b-form-input v-model="contactData.addressLine2"></b-form-input>
                            </b-col>
                        </b-row>
                        
                        <b-row>
                            <b-col>
                                <label>City</label>
                                <b-form-input v-model="contactData.city"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Provence</label>
                                <b-form-input v-model="contactData.provence"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col class="col-2">
                                <label>Post Code</label>
                                <b-form-input v-model="contactData.postalCode"></b-form-input>
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
        contactData: {
            name: null,
            surname: null,
            mobile: null,
            landline: null,
            email: null,
            companyName: null,
            building: null,
            officePark: null,
            addressLine1: null,
            addressLine2: null,
            postalCode: null,
            city: null,
            provence: null,
            isActive: true,
            location: null,
            officeId: null,
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
        ...mapActions(["createNewContact", "getAllOffice"]),
        
        goBack() {
            this.$router.back()
        },

        openSearchModal() {
            this.$bvModal.show('officeSearchModal')
            this.loadOffice()
        },
        hideSearchModal() {
            this.$bvModal.hide('officeSearchModal')
        },

        loadOffice() {
            this.getAllOffice()
                .then(response => {
                    this.officeTable.dataSource = response.data
                })
        },

        addOffice(rowItem) {
            this.hideSearchModal()
            this.contactData.location = rowItem.location
            this.contactData.officeId = rowItem.officeId
            console.log('ROW ITEM', rowItem)
        },
        
        save() {
            this.$store.commit('setCreateContactRequest', this.contactData)
            this.state = 'loading'
            this.createNewContact()
            .then(() => {
                this.goBack()
            })
            .catch((err) => {
                this.state = 'show'
                console.log("ERROR", err)
            })
        },
    },
    computed: {
        rows() {
            return this.officeTable.dataSource.length
        },
    },
}
</script>

<style scoped>

</style>