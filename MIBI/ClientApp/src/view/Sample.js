import React from 'react';
import { connect } from 'react-redux';
import { Route } from 'react-router';
import SearchField from "react-search-field";

const SampleView = props => (
    <div>
        <div>
            <h1>Here is going to be the search for samples!</h1>
        </div>
        <SearchField
            placeholder="Search..."
            onChange={() => { }}
            // TO DO: Fetch
            //searchText="Search for bacterias"
            //onEnter={() => { }}
            //onSearchClick={() => { }}
            classNames="test-class"
        />
        <Route render={({ history }) => (
            <button
                type='button'
                onClick={() => { history.push('/addSample') }}
            >
            Add Sample
            </button>
         )} />  
    </div>

);

export default connect()(SampleView);
