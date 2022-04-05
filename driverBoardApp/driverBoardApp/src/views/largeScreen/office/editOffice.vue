<template>
    <div>
        <b-row class="align-items-center vh-100 m-0 ">
            <b-col class="d-flex justify-content-center vw-100">
                <b-card class="w-50">
                    <b-row>
                        <B-col>
                            <div class="d-flex justify-content-between align-items-center">
                                <h4 class="m-0">Edit Office</h4>
                                <b-button variant="outline-red" squared @click="openDeleteModal" size="sm">Delete</b-button>
                            </div>
                        </B-col>
                    </b-row>
                    <B-form>
                        <b-row>
                            <b-col>
                                <label>Building</label>
                                <b-form-input v-model="selectedOffice.building"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Office Park</label>
                                <b-form-input v-model="selectedOffice.officePark"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Address</label>
                                <b-form-input v-model="selectedOffice.addressLine1"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Address</label>
                                <b-form-input v-model="selectedOffice.addressLine2"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>

                        </b-row>
                        <b-row>
                            <b-col>
                                <label>City</label>
                                <b-form-input v-model="selectedOffice.city"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Provence</label>
                                <b-form-input v-model="selectedOffice.provence"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col class="col-2">
                                <label>Post Code</label>
                                <b-form-input v-model="selectedOffice.postCode"></b-form-input>
                            </b-col>
                            <b-col cols="4">
                                <label>Location</label>
                                <b-form-input v-model="selectedOffice.location"></b-form-input>
                            </b-col>
                            <b-col class="col-3">
                                <label>Telephone Number</label>
                                <b-form-input v-model="selectedOffice.tellNumber"></b-form-input>
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
                                        <b-button variant="primary" squared @click="update" class="ml-2">Save</b-button>
                                    </div>
                                </div>
                            </b-col>
                        </b-row>
                    </B-form>
                </b-card>
            </b-col>
        </b-row>

        <b-modal id="officeDeleteModal" hide-footer hide-header-close class="text-center" title="Delete Office">
            <b-row>
                <b-col cols="12">
                    <label class="text-center">Are you sure you want to delete <span class="font-weight-bold text-red text-center">{{this.selectedOffice.location}} </span>branch?</label>
                </b-col>
            </b-row>
            <b-row>
                <b-col cols="12" class="text-center mt-3">
                    <b-button variant="outline-red" @click="hideDeleteModal" squared class="mr-2" >Cancel</b-button>
                    <b-button variant="red" @click="removeOffice" squared >Delete</b-button>
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
        this.getSelectedOffice()
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
        ...mapActions(["getOfficeDetails", "updateOffice"]),
        goBack() {
            this.$router.back()
        },
        
        getSelectedOffice() {
            if(this.$store.state.selectedOffice == null)
            {
                this.$router.back()
            }
            
            this.getOfficeDetails()
            .then((response) => {
                this.$store.commit("setSelectedOffice", response.data)
                console.log("DATA", response.data)
            })
        },
        
        update() {
            this.$store.commit('setSelectedOffice', this.selectedOffice)
            this.updateOffice()
            .then(() => {
                this.$router.back()
            })
            .catch(() => {
                this.state = 'show'
            })
        },
        
        openDeleteModal() {
            this.$bvModal.show('officeDeleteModal')
        },
        hideDeleteModal() {
            this.$bvModal.hide('officeDeleteModal')
        },
        
        removeOffice() {
            this.selectedOffice.isActive = false
            this.$store.commit('setSelectedOffice', this.selectedOffice)
            this.updateOffice()
            .then(() => {
                this.$router.back()                
            })
        },
    },
    computed: {
        ...mapState([
            "selectedOffice"
        ])
    },
}
</script>

<style scoped>

</style>