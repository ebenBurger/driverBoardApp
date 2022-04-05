<template>
    <div>
        <div>
            <b-row>
                <b-col>
                    <b-card>
                        <b-row>
                            <b-col>
                                <div class="d-flex justify-content-between align-items-center">
                                    <h4 class="m-0">Drivers</h4>
                                </div>
                                <b-col class="text-right">
                                    <b-button variant="outline-primary" size="sm" squared @click="addDriver">
                                        <font-awesome-icon icon="fa-plus" class="mr-1"/> Driver
                                    </b-button>
                                </b-col>
                            </b-col>
                        </b-row>

                        <b-row class="mt-3">
                            <b-col>
                                <B-table
                                    striped hover
                                    :items="driverTable.dataSource"
                                    :fields="driverTable.tableColumns"
                                    :busy="driverTable.isLoading"
                                    @row-clicked="openDriver"
                                    id="vehicleTable"
                                    :current-page="driverTable.currentPage">

                                    <template #table-busy>
                                        <div class="text-center my-2">
                                            <b-spinner style="width: 3rem; height: 3rem;"></b-spinner>
                                        </div>
                                    </template>

                                    <template #cell(actions)="row">
                                        <b-row align-v="center" align-h="end">
                                            <b-button @click="openDriver(row.item)" size="sm" class="btn-icon">
                                                <b-icon-chevron-right></b-icon-chevron-right>
                                            </b-button>
                                        </b-row>
                                    </template>

                                </B-table>

                                <b-row align-h="center" >
                                    <b-pagination
                                        v-model="driverTable.currentPage"
                                        :total-rows="rows"
                                        :per-page="driverTable.resultsPerPage"
                                        aria-controls="contactTable"
                                    ></b-pagination>
                                </b-row>

                            </b-col>
                        </b-row>
                    </b-card>
                </b-col>
            </b-row>
        </div>
    </div>
</template>

<script>
import {mapActions} from "vuex";

export default {
    data: () => ({
        driverTable: {
            resultsPerPage: 10,
            currentPage: 1,
            dataSource: [],
            isLoading: false,
            tableColumns: [
                {
                    label: 'Name',
                    key: 'name',
                    sortable: true,
                    tdClass:'',
                },
                {
                    label: 'Surname',
                    key: 'surname',
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
        this.driverRequest()
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
        ...mapActions(["getAllDriver"]),
        addDriver() {
            this.$router.push({path: '/addDriver'})
        },
        openDriver(driver) {
            this.$store.commit('setSelectedDriver', driver)
            this.$router.push({path: '/editDriver'})
        },
        driverRequest() {
            this.driverTable.isLoading = true
            
            const request = []
            this.$store.commit('setDriverRequest', request)
            this.getAllDriver()
            .then((response) => {
                this.driverTable.isLoading = false
                this.driverTable.dataSource = response.data
            })
        },
    },
    computed: {
        rows() {
            return this.driverTable.dataSource.length
        }
    },
}
</script>

<style scoped>

</style>