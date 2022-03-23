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
                        </b-col>
                    </b-row>
                    
                    <b-row class="mt-3">
                        <b-col>
                            <b-card>
                                <b-row>
                                    <b-col>
                                        <B-table
                                            striped hover
                                            :items="vehicleData.dataSource"
                                            :fields="vehicleData.tableColumns"
                                            :busy="vehicleData.isLoading"
                                            @row-clicked="openVehicle"
                                            id="vehicleTable"
                                            :current-page="vehicleData.currentPage">

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
                                    </b-col>
                                </b-row>
                                
                                <b-row align-h="center" >
                                    <b-pagination
                                        v-model="vehicleData.currentPage"
                                        :total-rows="rows"
                                        :per-page="vehicleData.resultsPerPage"
                                        aria-controls="contactTable"
                                    ></b-pagination>
                                </b-row>
                                
                            </b-card>
                        </b-col>
                    </b-row>
                </b-card>
            </b-col>
        </b-row>
    </div>
</template>

<script>
export default {
    name: "main",
    data: () => ({
        state: 'loading',
        vehicleData: {
            resultsPerPage: 10,
            currentPage: 1,
            dataSource: [
                {id: 1, make: 'UP', model: 'VW', location: 'JHB'},
                {id: 2, make: 'Hyundai', model: 'H-100', location: 'JHB'},
                {id: 1, make: 'UP', model: 'VW', location: 'CPT'},
                {id: 2, make: 'Hyundai', model: 'H-100', location: 'CPT'},
            ],
            isLoading: false,
            tableColumns: [
                {
                    label: 'Make',  
                    key: 'make',
                    sortable: true,
                    tdClass:'',
                },
                {
                    label: 'Model',
                    key: 'model',
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
        }
    }),
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
        openVehicle(vehicle) {
            console.log('VEHICLE', vehicle)
        },
    },
    computed: {
        rows() {
            return this.vehicleData.dataSource.length
        }
    },
}
</script>

<style scoped>
    
</style>