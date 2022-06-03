<template>
    <div>
        <h1 id="title" class="mx-4" />
        <v-divider color="success" class="ma-2" />
        <v-app>
            <v-form
                ref="form"
                v-model="isFormValid"
                id="watermarkForm"
                lazy-validation
            >
                <v-container>
                    <v-row justify="center">
                        <v-flex shrink class="pb-10">
                            <v-container style="max-height: 80px">
                                <v-row justify="center">
                                    <h2 class="mx">General</h2>
                                </v-row>
                            </v-container>
                            <v-container style="max-height: 80px">
                                <v-text-field
                                    v-model="addEditWatermark.name"
                                    :rules="textRules"
                                    label="Name"
                                    required
                                ></v-text-field>
                            </v-container>
                            <v-container
                                class="d-flex"
                                style="max-height: 80px"
                            >
                                <v-select
                                    v-model="selectedMode"
                                    @change="modeChanged"
                                    :items="modes"
                                    item-value="id"
                                    item-text="name"
                                    label="Mode"
                                    required
                                ></v-select>
                                <v-tooltip v-model="modeShow" top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-icon
                                            class="pl-2"
                                            color="grey"
                                            v-ripple="false"
                                            :retain-focus="false"
                                            v-bind="attrs"
                                            v-on="on"
                                        >
                                            mdi-help-circle-outline
                                        </v-icon>
                                    </template>
                                    <span>Recommended Thread Count: 0</span>
                                </v-tooltip>
                            </v-container>
                        </v-flex>
                        <v-divider
                            style="max-height: 720px"
                            vertical
                            color="grey"
                        ></v-divider>
                        <v-flex shrink class="pb-10">
                            <v-container style="max-height: 80px">
                                <v-row justify="center">
                                    <h2 class="mx">Image</h2>
                                </v-row>
                            </v-container>
                            <v-container
                                class="d-flex"
                                style="max-height: 80px"
                            >
                                <v-select
                                    v-model="selectedImageSource"
                                    @change="imageSourceChanged"
                                    :items="imageSources"
                                    item-value="id"
                                    item-text="name"
                                    label="Image Source"
                                    required
                                ></v-select>
                                <v-tooltip v-model="imageSourceShow" top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-icon
                                            class="pl-2"
                                            color="grey"
                                            v-ripple="false"
                                            :retain-focus="false"
                                            v-bind="attrs"
                                            v-on="on"
                                        >
                                            mdi-help-circle-outline
                                        </v-icon>
                                    </template>
                                    <span>Recommended Thread Count: 0</span>
                                </v-tooltip>
                            </v-container>
                            <v-container
                                class="d-flex"
                                justify-end
                                style="max-height: 80px"
                            >
                                <v-btn
                                    color="success"
                                    class="ma-4"
                                    @click="addRecord()"
                                    ><v-icon>mdi-cloud-upload</v-icon>
                                    <div class="pl-3">UPLOAD IMAGE</div>
                                </v-btn>
                            </v-container>
                            <v-container
                                class="d-flex"
                                style="max-height: 80px"
                            >
                                <v-select
                                    v-model="selectedLocation"
                                    @change="locationChanged"
                                    :items="locations"
                                    item-value="id"
                                    item-text="name"
                                    label="Location"
                                    required
                                ></v-select>
                                <v-tooltip v-model="locationShow" top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-icon
                                            class="pl-2"
                                            color="grey"
                                            v-ripple="false"
                                            :retain-focus="false"
                                            v-bind="attrs"
                                            v-on="on"
                                        >
                                            mdi-help-circle-outline
                                        </v-icon>
                                    </template>
                                    <span>Recommended Thread Count: 0</span>
                                </v-tooltip>
                            </v-container>
                            <v-container class="d-flex">
                                <v-select
                                    v-model="selectedSize"
                                    @change="sizeChanged"
                                    :items="sizes"
                                    item-value="id"
                                    item-text="name"
                                    label="Size"
                                    required
                                ></v-select>
                                <v-tooltip v-model="sizeShow" top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-icon
                                            class="pl-2"
                                            color="grey"
                                            v-ripple="false"
                                            :retain-focus="false"
                                            v-bind="attrs"
                                            v-on="on"
                                        >
                                            mdi-help-circle-outline
                                        </v-icon>
                                    </template>
                                    <span>Recommended Thread Count: 0</span>
                                </v-tooltip>
                            </v-container>
                            <v-container class="d-flex">
                                <v-text-field
                                    v-model="addEditWatermark.width"
                                    :rules="validPercent"
                                    label="Width"
                                    suffix="%"
                                    required
                                ></v-text-field>
                                <v-tooltip v-model="widthShow" top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-icon
                                            class="pl-2"
                                            color="grey"
                                            v-ripple="false"
                                            :retain-focus="false"
                                            v-bind="attrs"
                                            v-on="on"
                                        >
                                            mdi-help-circle-outline
                                        </v-icon>
                                    </template>
                                    <span>Recommended Thread Count: 0</span>
                                </v-tooltip>
                            </v-container>
                            <v-container class="d-flex">
                                <v-text-field
                                    v-model="addEditWatermark.horizontalMargin"
                                    :rules="validPercent"
                                    label="Horizontal Margin"
                                    suffix="%"
                                    required
                                ></v-text-field>
                                <v-tooltip v-model="horizontalMarginShow" top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-icon
                                            class="pl-2"
                                            color="grey"
                                            v-ripple="false"
                                            :retain-focus="false"
                                            v-bind="attrs"
                                            v-on="on"
                                        >
                                            mdi-help-circle-outline
                                        </v-icon>
                                    </template>
                                    <span>Recommended Thread Count: 0</span>
                                </v-tooltip>
                            </v-container>
                            <v-container class="d-flex">
                                <v-text-field
                                    v-model="addEditWatermark.verticalMargin"
                                    :rules="validPercent"
                                    label="Vertical Margin"
                                    suffix="%"
                                    required
                                ></v-text-field>
                                <v-tooltip v-model="verticalMarginShow" top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-icon
                                            class="pl-2"
                                            color="grey"
                                            v-ripple="false"
                                            :retain-focus="false"
                                            v-bind="attrs"
                                            v-on="on"
                                        >
                                            mdi-help-circle-outline
                                        </v-icon>
                                    </template>
                                    <span>Recommended Thread Count: 0</span>
                                </v-tooltip>
                            </v-container>
                            <v-container class="d-flex">
                                <v-text-field
                                    v-model="addEditWatermark.opacity"
                                    :rules="validPercent"
                                    label="Opacity"
                                    suffix="%"
                                    required
                                ></v-text-field>
                                <v-tooltip v-model="opacityShow" top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-icon
                                            class="pl-2"
                                            color="grey"
                                            v-ripple="false"
                                            :retain-focus="false"
                                            v-bind="attrs"
                                            v-on="on"
                                        >
                                            mdi-help-circle-outline
                                        </v-icon>
                                    </template>
                                    <span>Recommended Thread Count: 0</span>
                                </v-tooltip>
                            </v-container>
                        </v-flex>
                        <v-divider
                            style="max-height: 720px"
                            vertical
                            color="grey"
                        ></v-divider>
                        <v-flex shrink class="pb-10">
                            <v-container style="max-height: 80px">
                                <v-row justify="center">
                                    <h2 class="mx">Time</h2>
                                </v-row>
                            </v-container>
                            <v-container class="d-flex">
                                <v-select
                                    v-model="selectedFrequencyMinutes"
                                    @change="frequencyMinutesChanged"
                                    :items="frequencyMinutes"
                                    item-value="id"
                                    item-text="name"
                                    label="Frequency"
                                    required
                                ></v-select>
                                <v-tooltip v-model="frequencyShow" top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-icon
                                            class="pl-2"
                                            color="grey"
                                            v-ripple="false"
                                            :retain-focus="false"
                                            v-bind="attrs"
                                            v-on="on"
                                        >
                                            mdi-help-circle-outline
                                        </v-icon>
                                    </template>
                                    <span>Recommended Thread Count: 0</span>
                                </v-tooltip>
                            </v-container>
                            <v-container class="d-flex">
                                <v-text-field
                                    v-model="addEditWatermark.durationSeconds"
                                    :rules="validDuration"
                                    label="Duration"
                                    suffix="seconds"
                                    required
                                ></v-text-field>
                                <v-tooltip v-model="durationShow" top>
                                    <template v-slot:activator="{ on, attrs }">
                                        <v-icon
                                            class="pl-2"
                                            color="grey"
                                            v-ripple="false"
                                            :retain-focus="false"
                                            v-bind="attrs"
                                            v-on="on"
                                        >
                                            mdi-help-circle-outline
                                        </v-icon>
                                    </template>
                                    <span>Recommended Thread Count: 0</span>
                                </v-tooltip>
                            </v-container>
                            <v-container>
                                <v-btn
                                    color="green lighten-1"
                                    class="ma-2"
                                    :disabled="!isFormValid"
                                    @click="saveWatermark()"
                                >
                                    Save Watermark
                                </v-btn>
                                <v-btn
                                    color="cancel"
                                    class="ma-2"
                                    @click="cancelAdd()"
                                >
                                    Cancel
                                </v-btn>
                                <v-btn
                                    color="indigo accent-1"
                                    class="ma-2"
                                    @click="cancelAdd()"
                                >
                                    Help
                                </v-btn>
                            </v-container>
                        </v-flex>
                    </v-row>
                </v-container>
            </v-form>
        </v-app>
    </div>
</template>

<script lang="ts">
import { Vue, Component, Watch } from 'vue-property-decorator';
import { watermarkApiService } from '@/services/WatermarkService';
//import { Watermark } from '@/models/Watermark';
//import { WatermarkFull } from '../models/WatermarkFull';

@Component
export default class AddEditWatermark extends Vue {
    //private newWatermark: WatermarkFull = {};
    private addEditWatermark: any = {};
    private isFormValid = false;
    private modeShow = false;
    private imageSourceShow = false;
    private locationShow = false;
    private sizeShow = false;
    private widthShow = false;
    private horizontalMarginShow = false;
    private verticalMarginShow = false;
    private opacityShow = false;
    private frequencyShow = false;
    private durationShow = false;

    private _selectedMode: number = 2;
    private selectedMode: { id: number; name: string } = {
        id: 1,
        name: 'Permanent'
    };
    private modes: [
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string }
    ] = [
        { id: 0, name: 'None' },
        { id: 1, name: 'Permanent' },
        { id: 2, name: 'Intermittent' }
    ];

    private _selectedImageSource: number = 1;
    private selectedImageSource: { id: number; name: string } = {
        id: 0,
        name: 'Custom'
    };
    private imageSources: [
        { id: number; name: string },
        { id: number; name: string }
    ] = [
        { id: 0, name: 'Custom' },
        { id: 1, name: 'Channel Logo' }
    ];

    private _selectedLocation: number = 0;
    private selectedLocation: { id: number; name: string } = {
        id: 0,
        name: 'Bottom Right'
    };
    private locations: [
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string }
    ] = [
        { id: 0, name: 'Bottom Right' },
        { id: 1, name: 'Bottom Middle' },
        { id: 2, name: 'Bottom Left' },
        { id: 3, name: 'Left Middle' },
        { id: 4, name: 'Top Left' },
        { id: 5, name: 'Top Middle' },
        { id: 6, name: 'Top Right' },
        { id: 7, name: 'Right Middle' }
    ];

    private _selectedSize: number = 0;
    private selectedSize: { id: number; name: string } = {
        id: 0,
        name: 'Scaled'
    };
    private sizes: [
        { id: number; name: string },
        { id: number; name: string }
    ] = [
        { id: 0, name: 'Scaled' },
        { id: 1, name: 'Actual Size' }
    ];

    private _selectedFrequencyMinutes: number = 2;
    private selectedFrequencyMinutes: { id: number; name: string } = {
        id: 2,
        name: '15 minutes'
    };
    private frequencyMinutes: [
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string },
        { id: number; name: string }
    ] = [
        { id: 0, name: '5 minutes' },
        { id: 1, name: '10 minutes' },
        { id: 2, name: '15 minutes' },
        { id: 3, name: '20 minutes' },
        { id: 4, name: '30 minutes' },
        { id: 5, name: '60 minutes' }
    ];

    saveWatermark() {
        if (isNaN(this.id)) {
            watermarkApiService.newWatermark(
                this.addEditWatermark.name,
                this.addEditWatermark.image,
                this._selectedMode,
                this._selectedLocation,
                this._selectedImageSource,
                this._selectedSize,
                this.addEditWatermark.width,
                this.addEditWatermark.horizonalMargin,
                this.addEditWatermark.verticalMargin,
                this._selectedFrequencyMinutes,
                this.addEditWatermark.durationSeconds,
                this.addEditWatermark.opacity
            );
        } else {
            watermarkApiService.updateWatermark(
                this.id,
                this.addEditWatermark.name,
                this.addEditWatermark.image,
                this._selectedMode,
                this._selectedLocation,
                this._selectedImageSource,
                this._selectedSize,
                this.addEditWatermark.width,
                this.addEditWatermark.horizonalMargin,
                this.addEditWatermark.verticalMargin,
                this._selectedFrequencyMinutes,
                this.addEditWatermark.durationSeconds,
                this.addEditWatermark.opacity
            );
        }
    }

    private modeChanged(selectObj: number) {
        this._selectedMode = selectObj;
    }

    private imageSourceChanged(selectObj: number) {
        this._selectedImageSource = selectObj;
    }

    private locationChanged(selectObj: number) {
        this._selectedLocation = selectObj;
    }

    private sizeChanged(selectObj: number) {
        this._selectedSize = selectObj;
    }

    private frequencyMinutesChanged(selectObj: number) {
        this._selectedFrequencyMinutes = selectObj;
    }

    get validIntNonZero() {
        return [
            (v: any) => (v && /^[0-9]+$/.test(v)) || 'Must be a valid number.',
            (v: any) => (v && v > 0) || 'Must be greater than 0.'
        ];
    }

    get validPercent() {
        return [
            (v: any) => (v && /^[0-9]+$/.test(v)) || 'Must be a valid number.',
            (v: any) => (v && v > 0) || 'Must be greater than 0.',
            (v: any) => (v && v <= 100) || 'Must be less than or equal to 100.'
        ];
    }

    get validDuration() {
        return [
            (v: any) => (v && /^[0-9]+$/.test(v)) || 'Must be a valid number.',
            (v: any) => (v && v > 0) || 'Must be greater than 0.',
            (v: any) => (v && v <= 900) || 'Must be less than or equal to 900.'
        ];
    }

    get textRules() {
        return [(v: any) => (v && v.length > 0) || 'Value must not be empty.'];
    }

    private loaded = false;
    private id = -1;

    title: string = 'Add/Edit Watermark';

    props!: { id: number };
    @Watch('id', { immediate: true }) async onItemChanged() {
        console.log('ID', this.id);
        this.id = Number(this.$route.query.id) ?? -1;
        await this.loadPage();
    }

    async loadPage(): Promise<void> {
        if (this.loaded) {
            return;
        }
        var title = document.getElementById('title');
        if (title === null || title === undefined) {
            //sometimes the element isn't loaded yet, it'll come
            //back to this when it's good to go. So skip for now.
            return;
        }
        if (!isNaN(this.id)) {
            title.innerHTML = 'Edit Watermark';
            var watermarkFull = await watermarkApiService.getOne(
                this.id.toString()
            );
            var result = watermarkFull[0];
            if (result !== undefined) {
                //We have a watermark, let's load it.
                this.addEditWatermark = {
                    name: result.name ?? '',
                    image: result.image,
                    width: result.width,
                    horizontalMargin: result.horizontalmargin,
                    verticalMargin: result.verticalmargin,
                    durationSeconds: result.durationseconds,
                    opacity: result.opacity
                };

                this._selectedMode = result.mode;
                this.selectedMode = this.modes[result.mode];
                this._selectedLocation = result.location;
                this.selectedLocation = this.locations[result.location];
                this._selectedImageSource = result.imagesource;
                this.selectedImageSource =
                    this.imageSources[result.imagesource];
                this._selectedSize = result.size;
                this.selectedSize = this.sizes[result.size];
                this._selectedFrequencyMinutes = result.frequencyminutes;
                this.selectedFrequencyMinutes =
                    this.frequencyMinutes[result.frequencyminutes];
                //this.applyVaapiValidation();
                this.loaded = true;
            } else {
                //an ID was entered (probably in the URL) that doesn't exist. Let's returnt to the profile list.
                console.log('No watermark found for ID: ' + this.id);
                this.$router.push({
                    name: 'watermarks.title'
                });
            }
        } else {
            //new profile!
            title.innerHTML = 'Add Watermark';
            this._selectedMode = 2;
            this._selectedLocation = 0;
            this._selectedImageSource = 0;
            this._selectedSize = 0;
            this._selectedFrequencyMinutes = 2;
            this.addEditWatermark = {
                name: '',
                image: '',
                width: 15,
                horizontalMargin: 5,
                verticalMargin: 5,
                durationSeconds: 15,
                opacity: 100
            };
            this.loaded = true;
        }
    }
}
</script>
