import { AbstractApiService } from './AbstractApiService';
import { Watermark } from '@/models/Watermark';
import { WatermarkFull } from '@/models/WatermarkFull';

class WatermarkApiService extends AbstractApiService {
    public constructor() {
        super();
    }

    public getAll(): Promise<Watermark[]> {
        return this.http
            .get('/api/watermarks')
            .then(this.handleResponse.bind(this))
            .catch(this.handleError.bind(this));
    }

    public getOne(id: string): Promise<WatermarkFull[]> {
        return this.http
            .get('/api/watermarks/new' + id)
            .then(this.handleResponse.bind(this))
            .catch(this.handleResponse.bind(this));
    }

    public newWatermark(
        Name: string,
        Image: string,
        Mode: number,
        Location: number,
        ImageSource: number,
        Size: number,
        Width: number,
        HorizontalMargin: number,
        VerticalMargin: number,
        FrequencyMinutes: number,
        DurationSeconds: number,
        Opacity: number
    ) {
        const data = {
            Name: Name,
            Image: Image,
            Mode: Mode,
            Location: Location,
            ImageSource: ImageSource,
            Size: Size,
            Width: Width,
            HorizontalMargin: HorizontalMargin,
            VerticalMargin: VerticalMargin,
            FrequencyMinutes: FrequencyMinutes,
            DurationSeconds: DurationSeconds,
            Opacity: Opacity
        };
        this.http.post('/api/watermarks/new', data);
    }

    public updateWatermark(
        Id: number,
        Name: string,
        Image: string,
        Mode: number,
        Location: number,
        ImageSource: number,
        Size: number,
        Width: number,
        HorizontalMargin: number,
        VerticalMargin: number,
        FrequencyMinutes: number,
        DurationSeconds: number,
        Opacity: number
    ) {
        const data = {
            Id: Id,
            Name: Name,
            Image: Image,
            Mode: Mode,
            Location: Location,
            ImageSource: ImageSource,
            Size: Size,
            Width: Width,
            HorizontalMargin: HorizontalMargin,
            VerticalMargin: VerticalMargin,
            FrequencyMinutes: FrequencyMinutes,
            DurationSeconds: DurationSeconds,
            Opacity: Opacity
        };
        this.http.post('/api/watermarks/update', data);
    }

    public deleteRecord(id: string) {
        this.http.delete('/api/ffmpeg/delete/' + id);
    }
}

export const watermarkApiService: WatermarkApiService =
    new WatermarkApiService();
