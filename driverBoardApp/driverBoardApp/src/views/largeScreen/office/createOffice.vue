<template>
    <div>
        <b-row class="align-items-center vh-100 m-0 ">
            <b-col class="d-flex justify-content-center vw-100">
                <b-card class="w-50">
                    <b-row>
                        <B-col>
                            <h4>Add Office</h4>
                        </B-col>
                    </b-row>
                    <B-form>
                        <b-row>
                            <b-col>
                                <label>Building</label>
                                <b-form-input v-model="officeData.building"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Office Park</label>
                                <b-form-input v-model="officeData.officePark"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>Address Line 1</label>
                                <b-form-input v-model="officeData.addressLine1"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Address Line 2</label>
                                <b-form-input v-model="officeData.addressLine2"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            
                        </b-row>
                        <b-row>
                            <b-col>
                                <label>City</label>
                                <b-form-input v-model="officeData.city"></b-form-input>
                            </b-col>
                            <b-col>
                                <label>Provence</label>
                                <b-form-input v-model="officeData.provence"></b-form-input>
                            </b-col>
                        </b-row>
                        <b-row>
                            <b-col class="col-2">
                                <label>Post Code</label>
                                <b-form-input v-model="officeData.postCode"></b-form-input>
                            </b-col>
                            <b-col cols="4">
                                <label>Location</label>
                                <b-form-input v-model="officeData.location"></b-form-input>
                            </b-col>
                            <b-col class="col-3">
                                <label>Telephone Number</label>
                                <b-form-input v-model="officeData.tellNumber"></b-form-input>
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
export default {
    data: () => ({
        officeData: {
            building: null,
            officePark: null,
            addressLine1: null,
            addressLine2: null,
            postCode: null,
            city: null,
            provence: null,
            location: null,
            tellNumber: null,
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
        goBack() {
            this.$router.back()
        },
        
        save() {},
    },
    computed: {},
}
</script>

<style scoped>

</style>