import React, { Component } from 'react'
import { connect } from 'react-redux'
import { Route } from 'react-router'
import "../styles/Sample.css"

class SampleView extends Component {
    constructor(props){
        super(props)

        this.state = {}
    }

    handleSearchBarClick(event) {
        let text = event.target.value
        alert(text)
    }

    render() {
        return(
        <div className="conteiner">
            <div className="searchingBar">
                <input
                    placeholder="Search..."
                    onChange={() => { }}
                    onSearchClick={this.handleSearchBarClick}
                    id="searchBar"
                />
                <button id="searchBtn"><img/></button>
                <Route render={({ history }) => (
                    <button
                        id="addSampleBtn"
                        type='button'
                        onClick={() => { history.push('/addSample') }}
                    >
                    Add Sample
                    </button>
                )} />
            </div>
        </div>
        )
    }
}

export default connect()(SampleView);
