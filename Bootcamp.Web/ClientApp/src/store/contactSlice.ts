import { SampleApi } from 'src/api';
import { createAsyncThunk, createSlice, type PayloadAction } from '@reduxjs/toolkit';

export type ContactData = Readonly<{
    id: number;
    firstName: string;
    lastName: string;
    contactType: string;
    contactAddress: string;
}>;

export type ContactState = Readonly<{
    isLoading: boolean;
    pageIndex: number;
    contactDatas: ContactData[];
}>;

export type ReceiveContactDatasPayload = Pick<ContactState, "contactDatas" | "pageIndex">;

const initialState: ContactState = {
    contactDatas: [],
    isLoading: false,
    pageIndex: 5
};

export const contactSlice = createSlice({
    name: 'contact',
    initialState,
    reducers: {
        requestContactDatas: (state, action: PayloadAction<number>) => {
            state.isLoading = true;
            state.pageIndex = action.payload;
        },
        receiveContactDatas: (state, action: PayloadAction<ReceiveContactDatasPayload>) => {
            debugger;
            const { contactDatas, pageIndex } = action.payload;
            if (pageIndex === state.pageIndex) {
                // Only accept the incoming data if it matches the most recent request.
                // This ensures we correctly handle out-of-order responses.
                state.isLoading = false;
                state.contactDatas = contactDatas;
                state.pageIndex = pageIndex;
            }
        }
    }
});

export const getContactDatasAsync = createAsyncThunk(
    'contact/getContactDatasAsync',
    async (pageIndex: number, { dispatch, getState }) => {
        // If param pageIndex === state.pageIndex, do not perform action
        const { pageIndex: stateIdx } = (getState as () => ContactState)();
        if (pageIndex === stateIdx) {
            return;
        }

        // Dispatch request to intialize loading phase
        dispatch(requestContactDatas(pageIndex));

        // Build http request and success handler in Promise<void> wrapper / complete processing
        try {
            const contactDatas = await SampleApi.getContactDatasAsync(pageIndex);
            const payload = { contactDatas, pageIndex };
            dispatch(receiveContactDatas(payload));
        } catch (e) {
            console.error(e);
        }
    }
);

export const { requestContactDatas, receiveContactDatas } = contactSlice.actions;

export default contactSlice.reducer;