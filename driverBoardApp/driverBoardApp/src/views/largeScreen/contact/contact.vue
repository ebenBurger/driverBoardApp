<template>
    <div>
        <b-row>
            <b-col>
                <b-card>
                    <b-row>
                        <b-col>
                            <div class="d-flex justify-content-between align-items-center">
                                <h4 class="m-0">Contact List</h4>
                            </div>
                            <b-col class="text-right">
                                <b-button variant="outline-primary" size="sm" squared @click="addContact">
                                    <font-awesome-icon icon="fa-plus" class="mr-1"/> Contact
                                </b-button>
                            </b-col>
                        </b-col>
                    </b-row>

                    <b-row class="mt-3">
                        <b-col>
                            <B-table
                                striped hover
                                :items="contactTable.dataSource"
                                :fields="contactTable.tableColumns"
                                :busy="contactTable.isLoading"
                                @row-clicked="openContact"
                                id="vehicleTable"
                                :current-page="contactTable.currentPage">

                                <template #table-busy>
                                    <div class="text-center my-2">
                                        <b-spinner style="width: 3rem; height: 3rem;"></b-spinner>
                                    </div>
                                </template>

                                <template #cell(actions)="row">
                                    <b-row align-v="center" align-h="end">
                                        <b-button @click="openContact(row.item)" size="sm" class="btn-icon">
                                            <b-icon-chevron-right></b-icon-chevron-right>
                                        </b-button>
                                    </b-row>
                                </template>

                            </B-table>

                            <b-row align-h="center" >
                                <b-pagination
                                    v-model="contactTable.currentPage"
                                    :total-rows="rows"
                                    :per-page="contactTable.resultsPerPage"
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
        contact:{
            name: null,
            surname: null,
            email: null,
            tellNumber: null,
            mobile: null,
            company: null,
            
        },
        contactTable: {
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
        addContact() {
            this.$router.push({path: '/addContact'})
        },
        openContact() {},
    },
    computed: {
        rows() {
            return this.contactTable.dataSource.length
        },
    },
}
</script>

<style scoped>

</style>