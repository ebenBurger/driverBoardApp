<template>
    <div>
        <b-row class="align-items-center vh-100 m-0 ">
            <b-col class="d-flex justify-content-center vw-100">
                <b-card class="w-50">
                    <b-row>
                        <B-col>
                            <div class="d-flex justify-content-between align-items-center">
                                <h4 class="m-0">Edit Contact</h4>
                                <b-button variant="outline-red" squared @click="openDeleteModal" size="sm">Delete</b-button>
                            </div>
                        </B-col>
                    </b-row>
                    <B-form>
                        <label class="text-primary font-weight-bold mb-4">Personal Details</label>
                        <b-row>
                            <b-col>
                                <label>Name</label>
                                <b-form-input v-model="selectedContact.name"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Surname</label>
                                <b-form-input v-model="selectedContact.surname"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Mobile Number</label>
                                <b-form-input v-model="selectedContact.mobile"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Landline</label>
                                <b-form-input v-model="selectedContact.landline"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col cols="6">
                                <label>Email</label>
                                <b-form-input v-model="selectedContact.email"></b-form-input>
                            </b-col>
                        </b-row>
                        <hr class="mx-3">
                        <label class="text-primary font-weight-bold mb-4">Company Details</label>
                        <b-row>
                            <b-col>
                                <label>Company Name</label>
                                <b-form-input v-model="selectedContact.companyName"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Client Location</label>
                                <b-input-group-append>
                                    <b-form-input disabled v-model="selectedContact.location"></b-form-input>
                                    <b-input-group-append>
                                        <b-button text="Button" variant="outline-primary" @click="openSearchModal" >Search</b-button>
                                    </b-input-group-append>
                                </b-input-group-append>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Building</label>
                                <b-form-input v-model="selectedContact.building"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Office Park</label>
                                <b-form-input v-model="selectedContact.officePark"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Address Line 1</label>
                                <b-form-input v-model="selectedContact.addressLine1"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Address Line 2</label>
                                <b-form-input v-model="selectedContact.addressLine2"></b-form-input>
                            </b-col>
                        </b-row>

                        <b-row>
                            <b-col>
                                <label>City</label>
                                <b-form-input v-model="selectedContact.city"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Provence</label>
                                <b-form-input v-model="selectedContact.provence"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col class="col-2">
                                <label>Post Code</label>
                                <b-form-input v-model="selectedContact.postalCode"></b-form-input>
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
                                        <b-button variant="primary" squared @click="updateContactDetails" class="ml-2">Update</b-button>
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

        <b-modal id="contactDeleteModal" hide-footer hide-header-close class="text-center" title="Delete Contact">
            <b-row>
                <b-col cols="12">
                    <label class="text-center">Are you sure you want to delete <span class="font-weight-bold text-red text-center">{{this.selectedContact.name}} {{this.selectedContact.surname}}</span>?</label>
                </b-col>
            </b-row>
            <b-row>
                <b-col cols="12" class="text-center mt-3">
                    <b-button variant="outline-red" @click="hideDeleteModal" squared class="mr-2" >Cancel</b-button>
                    <b-button variant="red" @click="removeContact" squared >Delete</b-button>
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
        ...mapActions(["getAllOffice", "getContactDetails", "updateContact"]),
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
                    console.log("CONTACT", this.selectedContact)
                })
        },

        addOffice(rowItem) {
            this.hideSearchModal()
            this.selectedContact.location = rowItem.location
            this.selectedContact.officeId = rowItem.officeId
            console.log('ROW ITEM', rowItem)
        },
        
        updateContactDetails() {
            this.$store.commit('setSelectedContact', this.selectedContact)
            this.updateContact()
            .then(() => {
                this.$router.back()
            })
        },

        openDeleteModal() {
            this.$bvModal.show('contactDeleteModal')
        },
        hideDeleteModal() {
            this.$bvModal.hide('contactDeleteModal')
        },
        removeContact() {
            this.selectedContact.isActive = false
            this.$store.commit('setSelectedContact', this.selectedContact)
            this.updateContact()
            .then(() => {
                this.$router.back()
            })
        },
    },
    computed: {
        ...mapState([
            "selectedContact"
        ]),
        rows() {
            return this.officeTable.dataSource.length
        },
    },
}
</script>

<style scoped>

</style>