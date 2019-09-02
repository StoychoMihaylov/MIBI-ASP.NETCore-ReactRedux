import React, { Component } from 'react'
import { connect } from 'react-redux'
import { Route } from 'react-router'
import { getAllNamesOfExistingSamples } from '../store/actions/SampleActions'
import "../styles/Sample.css"

class SampleView extends Component {

    async componentDidMount() {
        await this.props.fetchAllNamesOfExistingSamples()
    }

    render() {
        return(
        <div className="conteiner">
            <div className="searchingBar">
                <div>
                    <input
                        id="searchInput"
                        placeholder="Search..."
                        onChange={() => {}}
                    />
                    <div className="autocompleateNames">
                        {
                            this.props.autocompleteNamesOfSamples.map((rec, index) =>(
                            <div key={index}>
                                <p id={rec.id}>{rec.name}</p>
                            </div>
                        ))
                        }
                    </div>
                </div>
                <button id="searchBtn"><img alt=""/></button>
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

const mapStateToProps = state => {
    console.log(state)
    return {
      autocompleteNamesOfSamples: state.sample.autocompleteNamesOfSamples,
      isLoading: state.sample.isLoading,
      error: state.sample.error
    };
  };

const mapDispatchToProps = dispatch => {
    return {
        fetchAllNamesOfExistingSamples: () => dispatch(getAllNamesOfExistingSamples())
    };
  };

export default connect(mapStateToProps, mapDispatchToProps)(SampleView)
