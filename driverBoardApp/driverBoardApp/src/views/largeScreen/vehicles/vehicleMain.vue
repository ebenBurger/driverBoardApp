<template>
    <div>
        <b-row>
            <b-col>
                <b-card>
                    <b-row>
                        <b-col>
                            <div class="d-flex justify-content-between align-items-center">
                                <h4 class="m-0">Vehicle View</h4>
                            </div>
                            <b-col class="text-right">
                                <b-button variant="outline-primary" size="sm" squared @click="addVehicle">
                                    <font-awesome-icon icon="fa-plus" class="mr-1"/>Vehicle
                                </b-button>
                            </b-col>
                        </b-col>
                    </b-row>
                    
                    <b-row class="mt-3">
                        <b-col>
                            <B-table
                                striped hover
                                :items="vehicleTable.dataSource"
                                :fields="vehicleTable.tableColumns"
                                :busy="vehicleTable.isLoading"
                                @row-clicked="openVehicle"
                                id="vehicleTable"
                                :current-page="vehicleTable.currentPage">

                                <template #table-busy>
                                    <div class="text-center my-2">
                                        <b-spinner style="width: 3rem; height: 3rem;"></b-spinner>
                                    </div>
                                </template>

                                <template #cell(actions)="row">
                                    <b-row align-v="center" align-h="end">
                                        <b-button @click="openVehicle(row.item)" size="sm" class="btn-icon">
                                            <b-icon-chevron-right></b-icon-chevron-right>
                                        </b-button>
                                    </b-row>
                                </template>

                            </B-table>

                            <b-row align-h="center" >
                                <b-pagination
                                    v-model="vehicleTable.currentPage"
                                    :total-rows="rows"
                                    :per-page="vehicleTable.resultsPerPage"
                                    aria-controls="contactTable"
                                ></b-pagination>
                            </b-row>

                        </b-col>
                    </b-row>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>

<script>
import {mapActions} from "vuex";

export default {
    name: "main",
    data: () => ({
        state: 'loading',
        vehicleTable: {
            resultsPerPage: 10,
            currentPage: 1,
            dataSource: [],
            isLoading: false,
            tableColumns: [
                {
                    label: 'Make',  
                    key: 'makeVehicle',
                    sortable: true,
                    tdClass:'',
                },
                {
                    label: 'Model',
                    key: 'modelVehicle',
                    sortable: true,
                    tdClass:'',
                },
                {
                    label: 'Location',
                    key: 'office.location',
                    sortable: true,
                    tdClass:'',
                },
                {
                    label: 'Odometer',
                    key: 'odometer',
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
    created() {
        this.vehicleRequest()
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
        ...mapActions(['getAllVehiclesRequest']),
        
        vehicleRequest() {
            this.vehicleTable.isLoading = true
            
            const request = []
            this.$store.commit('setVehicleRequest', request)
            this.getAllVehiclesRequest()
            .then((response) => {
                this.vehicleTable.isLoading = false
                this.vehicleTable.dataSource = response.data
                console.log('VEHICLE', response.data)
            })
        },
        
        addVehicle() {
            this.$router.push({path: '/addVehicle'})
        },
        
        openVehicle(vehicle) {
            this.$store.commit('setSelectedVehicle', vehicle)
            this.$router.push({path: '/editVehicle'})
        },
    },
    computed: {
        rows() {
            return this.vehicleTable.dataSource.length
        }
    },
}
</script>

<style scoped>
    
</style>