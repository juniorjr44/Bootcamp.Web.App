import authReducer from './authSlice';
import formReducer from './formSlice';
import contactReducer from './contactSlice';
import { configureStore } from '@reduxjs/toolkit'

export const store = configureStore({
  reducer: {
    auth: authReducer,
    form: formReducer,
    contact: contactReducer
  }
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;

// Inferred type: {auth: AuthState, form: FormState, contact: contactState}
export type AppDispatch = typeof store.dispatch;