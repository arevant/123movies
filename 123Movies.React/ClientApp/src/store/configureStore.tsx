import { applyMiddleware, compose, createStore } from 'redux';
import { routerMiddleware } from 'connected-react-router';
import { History } from 'history';
import createRootReducer from './reducers';

export default function configureStore(history: History) {
    const initialState = {};
    const middleware = [
        routerMiddleware(history)
    ];

    const enhancers = [];
    const windowIfDefined = typeof window === 'undefined' ? null : window as any; // eslint-disable-line @typescript-eslint/no-explicit-any
    if (windowIfDefined && windowIfDefined.__REDUX_DEVTOOLS_EXTENSION__) {
        enhancers.push(windowIfDefined.__REDUX_DEVTOOLS_EXTENSION__());
    }

    return createStore(
        createRootReducer(history),
        initialState,
        compose(applyMiddleware(...middleware), ...enhancers)
    );
}
