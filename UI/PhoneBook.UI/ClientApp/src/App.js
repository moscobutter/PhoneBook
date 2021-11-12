import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import LoginManager from './components/LoginManager';
import PhoneBookManger from './components/PhoneBookManager';
import PrivateRoute from './components/security/PrivateRoute';

export default () => (
  <Layout>
        <PrivateRoute exact path='/' component={PhoneBookManger} />
        <Route exact path='/login' component={LoginManager} />
  </Layout>
);
