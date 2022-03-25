<template>
    <div>
        <b-row>
            <b-col>
                <b-card>
                    <b-row>
                        <b-col>
                            <div class="d-flex justify-content-between align-items-center">
                                <h4 class="m-0">Atrax Office Locations</h4>
                            </div>
                            <b-col class="text-right">
                                <b-button variant="outline-primary" size="sm" squared @click="addOffice">
                                    <font-awesome-icon icon="fa-plus" class="mr-1"/> Office
                                </b-button>
                            </b-col>
                        </b-col>
                    </b-row>

                    <b-row class="mt-3">
                        <b-col>
                            <B-table
                                striped hover
                                :items="officeTable.dataSource"
                                :fields="officeTable.tableColumns"
                                :busy="officeTable.isLoading"
                                @row-clicked="openOffice"
                                id="vehicleTable"
                                :current-page="officeTable.currentPage">

                                <template #table-busy>
                                    <div class="text-center my-2">
                                        <b-spinner style="width: 3rem; height: 3rem;"></b-spinner>
                                    </div>
                                </template>

                                <template #cell(actions)="row">
                                    <b-row align-v="center" align-h="end">
                                        <b-button @click="openOffice(row.item)" size="sm" class="btn-icon">
                                            <b-icon-chevron-right></b-icon-chevron-right>
                                        </b-button>
                                    </b-row>
                                </template>

                            </B-table>

                            <b-row align-h="center" >
                                <b-pagination
                                    v-model="officeTable.currentPage"
                                    :total-rows="rows"
                                    :per-page="officeTable.resultsPerPage"
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
                    key: 'office',
                    sortable: true,
                    tdClass:'',
                },
                {
                    label: 'Address',
                    key: 'address',
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
        openOffice() {},
        addOffice() {
            this.$router.push({path: '/addOffice'})
        },
    },
    computed: {
        rows(){
            return this.officeTable.dataSource.length
        },
    },
}
</script>

<style scoped>

</style>