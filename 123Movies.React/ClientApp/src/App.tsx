import * as React from 'react';
import { Route } from 'react-router-dom';
import Layout from './components/layout/layout';
import Home from './components/home/home';
import Login from './components/login/login';
import Logout from './components/logout/logout';
import MovieDetail from './components/moviedetail/moviedetail'
import './custom.css';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route exact path='/login' component={Login} />
        <Route exact path='/logout' component={Logout} />
        <Route exact path='/detail/:id' component={MovieDetail} />
    </Layout>
);
