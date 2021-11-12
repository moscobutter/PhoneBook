import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/AuthenticationManagement';
import Login from './security/Login';

const LoginManager = props => (
    <div>
        {Login(props)}
    </div>
    
);

export default connect(
    state => state.authenticationmanager,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(LoginManager);
