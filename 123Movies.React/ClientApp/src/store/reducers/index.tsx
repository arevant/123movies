import { reducer as formReducer } from 'redux-form'
import { connectRouter } from 'connected-react-router';
import { combineReducers } from 'redux';
import UserProfile from './userprofile';

export default (history: any) => combineReducers({
    router: connectRouter(history),
    form: formReducer,
    userProfile: UserProfile
});