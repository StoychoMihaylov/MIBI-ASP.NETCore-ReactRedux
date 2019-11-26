import React from 'react'
import { Route, Redirect } from 'react-router'
import Layout from './components/Layout'
import SearchSampleView from './view/SearchSamples'
import CreateNewSample from './view/CreateNewSample'
import DetailedSample from './view/DetailedSample'
import RegisterAccount from './view/RegisterAccount'
import LoginAccount from './view/LoginAccount'

const PrivateRoute = ({ component: Component, ...rest }) => (
    <Route {...rest} render={(props) => (
        localStorage.getItem('token') !== null
        ? <Component {...props} />
        : <Redirect to='/account/login' />
    )} />
)

export default () => (
    <Layout>
        <Route exact path='/account/login' component={LoginAccount} />
        <Route exact path='/account/registration' component={RegisterAccount} />
        <PrivateRoute exact path='/' component={SearchSampleView} />
        <PrivateRoute exact path='/addSample' component={CreateNewSample} />
        <PrivateRoute exact path='/sample/:id' component={DetailedSample} />
        <PrivateRoute exact path='/searchSamples' component={SearchSampleView} />
    </Layout>
)
