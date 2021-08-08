import { SET_USER_PROFILE, REMOVE_USER_PROFILE } from "../actions/userprofile";

const initialState = {
    userProfile: null
}

const UserProfile =  (state = initialState, action: any) => {
    switch (action.type) {
        case SET_USER_PROFILE:
            return {
                ...state,
                userProfile: action.value
            };
        case REMOVE_USER_PROFILE:
            return {
                ...state,
                userProfile: null
            };
        default:
            return state;
    }
}

export default UserProfile;