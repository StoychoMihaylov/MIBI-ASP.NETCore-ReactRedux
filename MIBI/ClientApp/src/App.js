import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import SearchSampleView from './view/SearchSamples'
import CreateNewSample from './view/CreateNewSample'
import DetailedSample from './view/DetailedSample';

export default () => (
    <Layout>
        <Route exact path='/' component={SearchSampleView} />
        <Route exact path='/searchSamples' component={SearchSampleView} />
        <Route path='/addSample' component={CreateNewSample} />
        <Route path='/sample/:id' component={DetailedSample} />
    </Layout>
);
