import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import SampleView from './view/Sample'
import CreateNewSample from './view/CreateNewSample'
import Counter from './components/Counter';
import FetchData from './components/FetchData';

export default () => (
    <Layout>
        <Route exact path='/' component={SampleView} />
        <Route path='/addSample' component={CreateNewSample} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    </Layout>
);
