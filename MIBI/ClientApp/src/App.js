import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import SampleView from './view/Sample'
import CreateNewSample from './view/CreateNewSample'

export default () => (
    <Layout>
        <Route exact path='/' component={SampleView} />
        <Route path='/addSample' component={CreateNewSample} />
    </Layout>
);
