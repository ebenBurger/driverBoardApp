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
                                        v-model="driverData.codeA"
                                        :variant="ACode"
                                        :pressed.sync="driverData.codeA"
                                        @click="toggleButtonCodeA"
                                    >Code A: {{driverData.codeA ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="driverData.codeA1"
                                        :variant="A1Code"
                                        :pressed.sync="driverData.codeA1"
                                        @click="toggleButtonCodeA1"
                                        class="ml-2"
                                    >Code A1: {{driverData.codeA1 ? 'Yes' : 'No'}}</b-button>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col>
                                    <b-button
                                        pill
                                        v-model="driverData.codeB"
                                        :variant="BCode"
                                        :pressed.sync="driverData.codeB"
                                        @click="toggleButtonCodeB"
                                        class="ml-2"
                                    >Code B: {{driverData.codeB ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="driverData.codeC"
                                        :variant="CCode"
                                        :pressed.sync="driverData.codeC"
                                        @click="toggleButtonCodeC"
                                        class="ml-2"
                                    >Code C: {{driverData.codeC ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="driverData.codeEB"
                                        :variant="EBCode"
                                        :pressed.sync="driverData.codeEB"
                                        @click="toggleButtonCodeEB"
                                        class="ml-2"
                                    >Code EB: {{driverData.codeEB ? 'Yes' : 'No'}}</b-button>
                                </b-col>
                            </b-row>
                            <b-row>
                                <b-col>
                                    <b-button
                                        pill
                                        v-model="driverData.codeEC1"
                                        :variant="EC1Code"
                                        :pressed.sync="driverData.codeEC1"
                                        @click="toggleButtonCodeEC1"
                                        class="ml-2"
                                    >Code EC1: {{driverData.codeEC1 ? 'Yes' : 'No'}}</b-button>
                                    <b-button
                                        pill
                                        v-model="driverData.codeEC"
                                        :variant="ECCode"
                                        :pressed.sync="driverData.codeEC"
                                        @click="toggleButtonCodeEC"
                                        class="ml-2"
                                    >Code EC: {{driverData.codeEC ? 'Yes' : 'No'}}</b-button>
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
            codeA: false,
            codeA1: false,
            codeB: false,
            codeC: false,
            codeEB: false,
            codeEC1: false,
            codeEC: false,
            officeId: null,
        },
        locations: [],
        selectedOffice: [],
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
    updated() {},
    methods: {
        ...mapActions(["createNewDriver", "getAllOffice" ]),
        goBack() {
            this.$router.back()
        },
        loadOffice() {
            this.getAllOffice()
                .then(response => {
                    this.locations = response.data
                })
        },
        
        save() {
            this.driverData.location = this.selectedOffice.location
            this.driverData.officeId = this.selectedOffice.officeId
            this.$store.commit('setCreateDriverRequest', this.driverData)
            this.createNewDriver()
            .then(() => {
                this.goBack()
                console.log("DRIVER", this.driverData)
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
    },
}
</script>

<style scoped>

.white {
    background-color: white;
    width: 200px;
    height: 50px;
    color: black;
}
.blue {
    width: 200px;
    height: 50px;
    background-color: blue;
    color: white;
}
</style>