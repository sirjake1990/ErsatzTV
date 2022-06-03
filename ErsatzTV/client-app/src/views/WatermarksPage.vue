<template>
    <div>
        <v-btn color="success" class="ma-4" @click="addRecord()"
            >Add Watermark</v-btn
        >
        <v-data-table
            :headers="headers"
            :items="watermarks"
            :sort-by="['name']"
            class="elevation-1"
        >
            <template v-slot:[`item.image`]="{ item }">
                <div class="p-2">
                    <v-img
                        :src="item.image"
                        :alt="item.name"
                        height="100px"
                    ></v-img>
                </div>
            </template>
            <template v-slot:[`item.actions`]="{ item }">
                <v-icon small class="mr-2" @click="editRow(item.id)">
                    mdi-lead-pencil
                </v-icon>
                <v-icon small @click.stop="deleteRecord(item.id, item.name)"
                    >mdi-delete</v-icon
                >
            </template>
        </v-data-table>
    </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator';
import { Watermark } from '@/models/Watermark';
import { watermarkApiService } from '@/services/WatermarkService';

@Component
export default class Watermarks extends Vue {
    private watermarks: Watermark[] = [];

    private dialog = false;

    get headers() {
        return [
            { text: this.$t('watermarks.table.name'), value: 'name' },
            {
                text: this.$t('watermarks.table.image'),
                value: 'image'
            },
            { text: this.$t('watermarks.table.mode'), value: 'mode' },
            { text: this.$t('watermarks.table.location'), value: 'location' },
            { text: 'Actions', value: 'actions', sortable: false }
        ];
    }

    addRecord() {
        this.$router.push({
            name: 'add-watermark'
        });
    }

    deleteRecord(record: any, recordName: any) {
        this.$swal
            .fire({
                title: 'Are you sure?',
                text: 'Delete "' + recordName + '" Watermark?',
                icon: 'warning',
                iconColor: '#4CAF50',
                showCancelButton: true,
                confirmButtonText: 'Yes'
            })
            .then((result) => {
                if (result.isConfirmed) {
                    let index = this.watermarks.findIndex(
                        (it) => it.id === record
                    );
                    this.watermarks.splice(index, 1);
                    //watermarkApiService.deleteRecord(String(record));
                    this.$swal.fire({
                        html: '"' + recordName + '" Watermark deleted.',
                        timer: 2200
                    });
                    this.$swal.fire(
                        'Deleted!',
                        '"' + recordName + '" Watermark deleted.',
                        'success'
                    );
                }
            });
    }

    editRow(id: any) {
        this.$router.push({
            name: 'edit-watermark',
            query: { id: id }
        });
    }

    title: string = 'Watermarks';

    async mounted(): Promise<void> {
        this.watermarks = await watermarkApiService.getAll();
    }
}
</script>
