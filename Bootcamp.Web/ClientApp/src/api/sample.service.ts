import { BaseService } from './base.service';
import type { ContactData } from '../store/contactSlice';

/**
 * SampleData API abstraction layer communication via Axios (typescript singleton pattern)
 */
class SampleService extends BaseService {
  private static _sampleService: SampleService;
  private static _controller: string = 'SampleData';

  private constructor(name: string) {
    super(name);
  }

  public static get Instance(): SampleService {
    return this._sampleService || (this._sampleService = new this(this._controller));
  }

    public async getContactDatasAsync(pageIndex: number): Promise<ContactData[]> {
        debugger;
        const url = `Contact/list/${pageIndex}`;
        const { data } = await this.$ExtApiHttp.get<ContactData[]>(url);
    return data;
  }
}

export const SampleApi = SampleService.Instance;
